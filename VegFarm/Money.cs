using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegFarm
{
    class Money
    {
        const int deposit = 2;
        const int immatureIncome = 3;
        const int matureIncome = 5;
        const int overgrowIncome = -1;

        int currentAmountOfMoney = 100;

        public void Deposit()
        {
            currentAmountOfMoney -= deposit;
        }

        public void Income(CellState state)
        {
            switch (state)
            {
                case CellState.Immature:
                    currentAmountOfMoney += immatureIncome;
                    break;
                case CellState.Mature:
                    currentAmountOfMoney += matureIncome;
                    break;
                case CellState.Overgrow:
                    currentAmountOfMoney += overgrowIncome;
                    break;
            }
        }

        public int GetCurrentMoney()
        {
            return currentAmountOfMoney;
        }
    }
}
