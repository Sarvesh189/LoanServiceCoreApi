using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace LoanService.InfrastructureServices
{
    public class MessageBrockerService
    {
        private readonly AmazonSQSConfig sqsConfig;
        private readonly AmazonSQSClient sqsClient;
        public MessageBrockerService()
        {
          

            //var chain = new CredentialProfileStoreChain(@"~/.aws/credentials");
            //AWSCredentials awsCredentials;
            //if (chain.TryGetAWSCredentials("development", out awsCredentials))
            //{
                sqsClient = new AmazonSQSClient("aws_access_key_id", "aws_secret_access_key", RegionEndpoint.USWest2);
            //}

            
            
        }

        public async Task SendMessage(string emi)
        {
            SendMessageRequest message = new SendMessageRequest();
            message.QueueUrl = "https://sqs.us-west-2.amazonaws.com/XXXX/MortgageQueue"; //change the XXX with the actual value from aws console sqs service
            message.MessageBody = $"This is EMI: {emi}";
           await sqsClient.SendMessageAsync(message);
            sqsClient.Dispose();
        }

    }
}
