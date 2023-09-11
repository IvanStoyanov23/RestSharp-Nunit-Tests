namespace RestSharp_Nunit_Test
{
	public class RootModel
	{
		public int page { get; set; }
		public int per_page { get; set; }
		public int total { get; set; }
		public int total_page { get; set; }
		public SupportModel support { get; set; }
        public List<DataModel> data { get; set; }
    }
    public class RootModel2
    {
        public DataModel data { get; set; }
        public SupportModel support { get; set; }
    }

	public class UserResponseBody
	{
		public string name { get; set; }
		public string id { get; set; }
		public string job { get; set; }
		public DateTime createdAt { get; set; }
	}
    public class DataModel
	{ 
		public int id { get; set; }
		public string email { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set;}
		public string avatar { get; set; }
	}

	public class SupportModel
	{
		public string url { get; set; }
		public string text { get; set; }
	}
}