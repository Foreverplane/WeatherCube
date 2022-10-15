using Newtonsoft.Json;
namespace Response.Geo {
	

// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
	public class LocalNames
	{
		public string tr { get; set; }
		public string en { get; set; }
		public string de { get; set; }
		public string te { get; set; }
		public string eo { get; set; }
		public string ar { get; set; }
		public string el { get; set; }
		public string es { get; set; }
		public string pl { get; set; }
		public string sr { get; set; }
		public string vi { get; set; }
		public string bn { get; set; }
		public string fa { get; set; }
		public string ja { get; set; }
		public string he { get; set; }
		public string be { get; set; }
		public string hi { get; set; }
		public string uk { get; set; }
		public string ur { get; set; }
		public string gr { get; set; }
		public string ta { get; set; }
		public string fr { get; set; }
		public string zh { get; set; }
		public string ko { get; set; }
		public string it { get; set; }
		public string ku { get; set; }
		public string pt { get; set; }
		public string ru { get; set; }
	}
	
	public class Root
	{
		public string name { get; set; }
		public LocalNames local_names { get; set; }
		public double lat { get; set; }
		public double lon { get; set; }
		public string country { get; set; }
		public string state { get; set; }
	}


}
