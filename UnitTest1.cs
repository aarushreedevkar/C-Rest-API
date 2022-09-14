using RestSharp;

namespace RestSharpTest
{
   
    public class Employee
    {
      public int id { get; set; }
      public string name { get; set; }   
      public int salary { get; set; }

        [TestClass]
        public class UnitTest1
        {
            RestClient client;
            [TestInitialize]

            public void Setup()
            {
             client = new RestSharp.RestClient("http://localhost:4000");

            }
            private IRestResponse getEmployeeList()
            {
                RestRequest request = new RestRequest("/employees",Method.GET);
                IRestResponse response = client.Execute(request);
                return response;
            }
        }


        [TestMethod]
        public void onCallingList_ReturnEmployeelist()
        {
            IRestResponse response = getEmployeeList();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode, OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>
            Assert.AreEqual(4,dataResponse.Count);
            foreach(Employee e in dataResponse)
            {
             Console.WriteLine("id:" +e.id  +"name:" +e.name +"salary:" +e.salary);
            }
        }
    }
}