resource "aws_iam_role" "lambda-function-exec-role" {
    name = "${local.lambdaName}-Exec-Role"
    assume_role_policy = data.aws_iam_policy_document.lambda-assume-role-policy-doc.json
}

data "aws_iam_policy_document" "lambda-assume-role-policy-doc" {
    statement {
        actions    = ["sts:AssumeRole"]
        effect     = "Allow"
        sid        = ""
        principals {
            type        = "Service"
            identifiers = ["lambda.amazonaws.com"]
        }
    }
}

resource "aws_iam_role_policy_attachment" "lambda-full-access-policy-attach" {
    role = aws_iam_role.lambda-function-exec-role.name
    policy_arn = "arn:aws:iam::aws:policy/AWSLambda_FullAccess"
}

resource "aws_iam_role_policy_attachment" "lambda-full-access-policy-cloudwatch-attach" {
    role = aws_iam_role.lambda-function-exec-role.name
    policy_arn = "arn:aws:iam::aws:policy/service-role/AWSLambdaBasicExecutionRole"
}

data "aws_iam_policy_document" "lambda-dynamo-access-policy-doc" {
    statement {
        effect  = "Allow"
        actions = [
            "dynamodb:GetItem",
            "dynamodb:DescribeTable",
            "dynamodb:PutItem",
            "dynamodb:UpdateItem",
            "dynamodb:BatchGetItem",
            "dynamodb:BatchWriteItem",
            "dynamodb:DeleteItem",
            "dynamodb:Query"
        ]
        resources = [
            "arn:aws:dynamodb:us-west-2:672009997609:table/${local.dynamoDbTableName}"
        ]
    }
}

resource "aws_iam_policy" "lambda-dynamo-access-policy" {
    name   = "${local.lambdaName}-Dynamo-Access-Policy"
    path   = "/acct-managed/"
    policy = data.aws_iam_policy_document.lambda-dynamo-access-policy-doc.json
}

resource "aws_iam_role_policy_attachment" "lambda-dynamo-access-policy-attach" {
    role = aws_iam_role.lambda-function-exec-role.name
    policy_arn = aws_iam_policy.lambda-dynamo-access-policy.arn
}
