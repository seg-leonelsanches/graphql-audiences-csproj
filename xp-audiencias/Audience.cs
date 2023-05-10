using System;
namespace xp_audiencias
{
	public class Audience
	{
		public String Id { get; set; }
		public String Key { get; set; }
		public String Name { get; set; }
		public UInt32 Size { get; set; }
		public String CreatedAt { get; set; }
		public User CreatedBy { get; set; }
		public AudienceDefinition Definition { get; set; }
	}
}

