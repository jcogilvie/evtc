using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScratchEVTCParser;
using ScratchEVTCParser.GameData;
using ScratchEVTCParser.Model;
using ScratchEVTCParser.Model.Agents;
using ScratchEVTCParser.Model.Encounters;

namespace ArcdpsLogManager.Logs
{
	public class LogFinder
	{
		/// <summary>
		/// Creates a new log collection that contains all logs contained in a directory including subdirectories
		/// </summary>
		/// <param name="directoryPath"></param>
		/// <returns></returns>
		public IEnumerable<LogData> GetFromDirectory(string directoryPath)
		{
			var files = Directory.EnumerateFiles(directoryPath, "*.evtc*", SearchOption.AllDirectories)
				.Where(x => x.EndsWith(".evtc") || x.EndsWith(".evtc.zip"));

			return files.Select(file => new LogData(new FileInfo(file)));
		}

		public IEnumerable<LogData> GetTesting()
		{
			var player1 = new LogPlayer("Testing player", ":Testing account.1234", 1, Profession.Thief, EliteSpecialization.Daredevil);
			var player2 = new LogPlayer("Testing player 2", ":Another account.1235", 1, Profession.Ranger, EliteSpecialization.Druid);
			var player3 = new LogPlayer("Testing player 3", ":ChronoGoddess.1236", 2, Profession.Mesmer, EliteSpecialization.Chronomancer);
			var players = new[] {player1, player2, player3};

			var dateStart1 = new DateTimeOffset(2018, 06, 15, 12, 13, 14, TimeSpan.Zero);
			var dateStart2 = new DateTimeOffset(2018, 06, 15, 13, 14, 15, TimeSpan.Zero);
			var dateStart3 = new DateTimeOffset(2018, 06, 15, 14, 15, 16, TimeSpan.Zero);

			var duration1 = new TimeSpan(0, 1, 0);
			var duration2 = new TimeSpan(0, 2, 0);
			var duration3 = new TimeSpan(0, 6, 0);

			var log1 = new LogData(null, players, "Sabetha the Saboteur", EncounterResult.Failure, dateStart1,
				duration1);
			var log2 = new LogData(null, players, "Sabetha the Saboteur", EncounterResult.Failure, dateStart2,
				duration2);
			var log3 = new LogData(null, players, "Sabetha the Saboteur", EncounterResult.Success, dateStart3,
				duration3);

			return Enumerable.Repeat(new[] {log1, log2, log3}, 8).SelectMany(x => x);
		}
	}
}