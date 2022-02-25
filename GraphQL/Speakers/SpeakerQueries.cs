using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Data;
using ConferencePlanner.GraphQL.DataLoader;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.GraphQL.Speakers
{
	[ExtendObjectType("Query")]
	public class SpeakerQueries
	{
		[UseApplicationDbContext]
		public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
					context.Speakers.ToListAsync();

		public Task<Speaker> GetSpeakerAsync(
			[ID(nameof(Speaker))] int id,
			SpeakerByIdDataLoader dataLoader,
			CancellationToken cancellationToken) =>
			dataLoader.LoadAsync(id, cancellationToken);
	}
}

