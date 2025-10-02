using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Regions;

public sealed record CreateRegion(string Name, Guid CountryId) : IRequest<Guid>;