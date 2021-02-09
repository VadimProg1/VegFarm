using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegFarm
{
    class Cell
    {
        private CellState state = CellState.Empty;

        const int plantedSpeed = 2;
        const int greenSpeed = 4;
        const int immatureSpeed = 5;
        const int matureSpeed = 8;
        int currentTime = 0;

        public void Plant()
        {
            state = CellState.Planted;
        }

        public void Harvest()
        {
            state = CellState.Empty;
            currentTime = 0;
        }

        public void NextTick()
        {
            switch (currentTime)
            {
                case plantedSpeed:
                    state = CellState.Green;
                    break;
                case greenSpeed:
                    state = CellState.Immature;
                    break;
                case immatureSpeed:
                    state = CellState.Mature;
                    break;
                case matureSpeed:
                    state = CellState.Overgrow;
                    break;
            }
            currentTime++;
        }

        public CellState GetState()
        {
            return state;
        }
    }
}
