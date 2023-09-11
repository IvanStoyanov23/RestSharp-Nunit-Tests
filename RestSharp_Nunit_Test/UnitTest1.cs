using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;

namespace RestSharp_Nunit_Test
{
    public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

        [Test]
        public void GET_GitHub_Repos()
        {
            //Arrange
            var client = new RestClient("https://api.github.com/");

            var request = new RestRequest("/users/ivanstoyanov23/repos", Method.Get);

            var response = client.Execute(request);

            //Act
            var repos = JsonSerializer.Deserialize<List<Repo>>(response.Content);

            //Assert
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Unexpected status code.");
            Assert.That(repos.Count, Is.EqualTo(6), "Unexpected Length.");
        }

        [Test]
        public void GET_GitHub_Issues()
        {
            //Arrange
            var client = new RestClient("https://api.github.com/");

            var request = new RestRequest("/repos/ivanstoyanov23/GitHub-Homework/issues", Method.Get);

            var response = client.Execute(request);

            //Act
            var issues = JsonSerializer.Deserialize<List<Repo>>(response.Content);


            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Unexpected status code.");
            Assert.That(issues.Count, Is.EqualTo(5), "Unexpected Length.");
        }

        [Test]
        public void GET_ReqRes_List_Users_Data() 
        {
            //Arrange
            var client = new RestClient("https://reqres.in/");

            var request = new RestRequest("api/users?page=2", Method.Get);
            var response = client.Execute(request);

            //Act
            RootModel apiData = JsonSerializer.Deserialize<RootModel>(response.Content);

            var firstUser = apiData.data[0];

            //Assert
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That(firstUser.id, Is.EqualTo(7));
        }

        [Test]
        public void GET_ReqRes_Single_User()
        {
            //Arrange
            var client = new RestClient("https://reqres.in/");

            var request = new RestRequest("api/users/2", Method.Get);
            var response = client.Execute(request);

            //Act
            RootModel2 apiData = JsonSerializer.Deserialize<RootModel2>(response.Content);

            //Assert
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That(apiData.data.id, Is.EqualTo(2));
        }

        [Test]
        public void GET_ReqRes_Single_User_Not_Found()
        {
            //Arrange
            var client = new RestClient("https://reqres.in/");

            var request = new RestRequest("api/users/23", Method.Get);
            var response = client.Execute(request);

            //Act
            RootModel2 apiData = JsonSerializer.Deserialize<RootModel2>(response.Content);

            //Assert
            Assert.That((int)response.StatusCode, Is.EqualTo(404));
        }

        [Test]
        public void POST_ReqRes_Single_User_Create()
        {
            //Arrange
            var client = new RestClient("https://reqres.in/");

            var request = new RestRequest("api/users", Method.Post);

            request.AddJsonBody(new { name = "morpheus", job = "leader" });

            var response = client.Execute(request);

            //Act
            UserResponseBody apiData = JsonSerializer.Deserialize<UserResponseBody>(response.Content);

            //Assert
            Assert.That((int)response.StatusCode, Is.EqualTo(201));
            Assert.That(apiData.name, Is.EqualTo("morpheus"));
        }

        [Test]
        public void Delete_ReqRes_Single_User()
        {
            //Arrange
            var client = new RestClient("https://reqres.in/");

            var request = new RestRequest("api/users/2", Method.Delete);

            var response = client.Execute(request);

            //Assert
            Assert.That((int)response.StatusCode, Is.EqualTo(204));
        }
    }

}