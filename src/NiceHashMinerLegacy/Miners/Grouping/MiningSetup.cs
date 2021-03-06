﻿using System.Collections.Generic;
using System.Linq;
using NiceHashMinerLegacy.Common.Enums;

namespace NiceHashMiner.Miners.Grouping
{
    public class MiningSetup
    {
        public List<MiningPair> MiningPairs { get; }
        public string MinerPath { get; }
        public string MinerName { get; }
        public AlgorithmType CurrentAlgorithmType { get; }
        public AlgorithmType CurrentSecondaryAlgorithmType { get; }
        public bool IsInit { get; }

        public IEnumerable<int> DeviceIDs => MiningPairs.Select(p => p.Device.ID);

        public MiningSetup(List<MiningPair> miningPairs)
        {
            IsInit = false;
            CurrentAlgorithmType = AlgorithmType.NONE;
            CurrentSecondaryAlgorithmType = AlgorithmType.NONE;
            if (miningPairs == null || miningPairs.Count <= 0) return;
            MiningPairs = miningPairs;
            MiningPairs.Sort((a, b) => a.Device.ID - b.Device.ID);
            MinerName = miningPairs[0].Algorithm.MinerName;
            CurrentAlgorithmType = miningPairs[0].Algorithm.NiceHashID;
            CurrentSecondaryAlgorithmType = miningPairs[0].Algorithm.SecondaryNiceHashID;
            MinerPath = miningPairs[0].Algorithm.MinerBinaryPath;
            IsInit = MinerPaths.IsValidMinerPath(MinerPath);
        }
    }
}
