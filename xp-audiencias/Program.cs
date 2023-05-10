// Primeiros passos:
// - Modificar a Bearer Token na linha 13;
// - Verificar a lógica a partir da linha 55.

using System.Net.Http.Headers;
using System.Security.Principal;

using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using xp_audiencias;

String bearerToken = "sua-bearer-token-aqui";
var _client = new GraphQLHttpClient("https://gateway-api.segment.com/graphql", new NewtonsoftJsonSerializer());
_client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");

var query = new GraphQLRequest
{
    Query = @"
                query spacesQuery {
                  workspace(slug: ""xp-investimentos"") {
                    spaces {
                      id
                      name
                      audiences {
                        data {
                          id
                          key
                          name
                          size
                          createdAt
                          createdBy {
                            email
                          }
                          definition {
                            options
                          }
                        }
                      }
                    }
                  }
                }",
};

var response = await _client.SendQueryAsync<ApiGatewayResponseData>(query);

/*
 * O objeto `ApiGatewayResponseData` contém o objeto `Workspace`, que contém o
 * restante das informações que interessam para o resultado. 
 * 
 * Aqui eu defino um laço de iteração que chama `Functions.TraverseAst`, um 
 * método estático de exemplo que uso para mostrar como iterar pelos elementos
 * obtidos pela pesquisa no GraphQL. 
 */
foreach (var space in response.Data.Workspace.Spaces)
{
    foreach (var audience in space.Audiences.Data)
    {
        Console.WriteLine($"Audience: {audience.Name}");
        Console.WriteLine($"Size: {audience.Size}");
        Console.WriteLine($"Created At: {audience.CreatedAt}");
        Console.WriteLine($"Created By: {audience.CreatedBy.Email}");
        Console.WriteLine("---");
        Console.WriteLine("Definition:");
        Functions.TraverseAst(audience.Definition.Options.Ast);
        Console.WriteLine("---");
    }
}
