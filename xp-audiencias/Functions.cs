using System;
namespace xp_audiencias
{
	public static class Functions
	{
		public static void TraverseAst(AudienceDefinitionAstNode node, Int32 ident = 0)
		{
			String identLevel = new String(' ', ident);

			Console.WriteLine($"{identLevel}Type: {node.Type}");
            Console.WriteLine($"{identLevel}Value: {node.Value}");
			Console.WriteLine($"{identLevel}Children: ");

			foreach (var child in node.Children ?? new List<AudienceDefinitionAstNode>())
			{
				TraverseAst(child, ident + 2);
			}
        }
	}
}

