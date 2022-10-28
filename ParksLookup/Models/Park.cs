namespace ParksLookup.Models
{
	public class Park
	{
		public int ParkId {get; set;}
		public string Name {get; set;}
		public string NatlOrState {get; set;}
		public DateTime OpenWhen {get; set;}
		public bool OpenNow {get; set;}
		public string Description {get; set;}
	}
}