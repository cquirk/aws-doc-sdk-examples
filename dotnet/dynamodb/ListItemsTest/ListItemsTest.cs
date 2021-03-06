// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved. 
// SPDX - License - Identifier: Apache - 2.0
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

using Moq;

using Xunit;
using Xunit.Abstractions;

namespace DynamoDBCRUD 
{
    public class ListItemsTest
    {
        private readonly ITestOutputHelper output;

        public ListItemsTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        readonly string _tableName = "testtable";        

        private IAmazonDynamoDB CreateMockDynamoDBClient()
        {
            var mockDynamoDBClient = new Mock<IAmazonDynamoDB>();

            mockDynamoDBClient.Setup(client => client.ScanAsync(
                It.IsAny<ScanRequest>(),
                It.IsAny<CancellationToken>()))
                .Callback<ScanRequest, CancellationToken>((request, token) =>
                {
                    if (!string.IsNullOrEmpty(_tableName))
                    {
                        bool areEqual = _tableName == request.TableName;
                        Assert.True(areEqual, "The provided table name is not the one used to access the table");
                    }
                })
                .Returns((ScanRequest r, CancellationToken token) =>
                {
                    return Task.FromResult(new ScanResponse { HttpStatusCode = HttpStatusCode.OK });
                });

            return mockDynamoDBClient.Object;
        }

        [Fact]
        public async Task CheckListItems()
        {
            IAmazonDynamoDB client = CreateMockDynamoDBClient();

            var result = await ListItems.GetItemsAsync(client, _tableName);

            bool gotResult = result != null;
            Assert.True(gotResult, "Could NOT get result from scanning table");

            bool ok = result.HttpStatusCode == HttpStatusCode.OK;
            Assert.True(ok, "Could NOT get items from scanning table");

            output.WriteLine("Got items from table");
        }
    }
}
