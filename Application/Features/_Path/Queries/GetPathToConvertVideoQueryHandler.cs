using MediatR;
using System.Xml;
using System.Xml.Linq;

namespace Application.Features._Path.Queries;

public class GetPathToConvertVideoQueryHandler
    : IRequestHandler<GetPathToConvertVideoQuery, string>
{
    public async Task<string> Handle(GetPathToConvertVideoQuery request, CancellationToken cancellationToken)
    {
        using var file = File.OpenRead("../locations.xml");

        var xDocument = await XDocument.LoadAsync(file, LoadOptions.None,cancellationToken);

        return xDocument.Root.Element("path-to-download-video").Value;
    }
}