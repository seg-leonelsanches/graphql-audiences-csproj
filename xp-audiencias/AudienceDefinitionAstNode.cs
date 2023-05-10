using System;
namespace xp_audiencias
{
	public class AudienceDefinitionAstNode
	{
		public String? Type { get; set; }
		public String? Value { get; set; }
		public List<AudienceDefinitionAstNode>? Children { get; set; }
		public AudienceDefinitionAstNodeOptions? Options { get; set; }
	}
}

