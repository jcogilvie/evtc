using System.Collections.Generic;
using ScratchEVTCParser.Model.Agents;

namespace ScratchEVTCParser.Model.Encounters
{
	public interface IEncounterNameProvider
	{
		string GetEncounterName();
	}

	public class AgentNameEncounterNameProvider : IEncounterNameProvider
	{
		private readonly Agent agent;

		public AgentNameEncounterNameProvider(Agent agent)
		{
			this.agent = agent;
		}

		public string GetEncounterName()
		{
			return agent.Name;
		}
	}
}