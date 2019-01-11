using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace catmashBack
{
    /// <summary>
    /// Implement ELO algo for rating system
    /// </summary>
    public static class EloUtils
    {
        public const int NBGAMENEWCOMER = 10;
        public const int KNEWCOMER = 20;
        public const int KCLASSIC = 40;

        public enum GameOutcome
        {
            Win = 1,
            Loss = -1,
            Draw = 0
        }


        private static Dictionary<GameOutcome, double> outcomeFactor = new Dictionary<GameOutcome, double>()
        {
            {GameOutcome.Win, 1 },
            {GameOutcome.Loss, 0 },
            {GameOutcome.Draw, 0.5 }
        };


        static double ExpectationToWin(int playerOneRating, int playerTwoRating)
        {
            return 1 / (1 + Math.Pow(10, (playerTwoRating - playerOneRating) / 400.0));
        }

        /// <summary>
        /// Calculate new ELO
        /// </summary>
        /// <param name="playerOneRating">Return updated ELO</param>
        /// <param name="playerTwoRating">Return updated ELO</param>
        /// <param name="outcome">Player one result</param>
        /// <param name="k">k factor to use, highest between both players</param>
        public static void CalculateELO(ref int playerOneRating, ref int playerTwoRating, GameOutcome outcome, int k)
        {
            int delta = (int)(k * (outcomeFactor[outcome] - ExpectationToWin(playerOneRating, playerTwoRating)));

            playerOneRating += delta;
            playerTwoRating -= delta;
        }
    }
}