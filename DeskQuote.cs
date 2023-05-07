using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{
    internal class DeskQuote
    {
        public string CustomerName { get; set; }
        public Desk Desk { get; set; }
        public string RushOrderOption { get; set; }
        public DateTime QuoteDate { get; set; }

        private const decimal BASE_DESK_PRICE = 200m;
        private const decimal PRICE_PER_DRAWER = 50m;
        private const decimal PRICE_PER_SQUARE_INCH = 1m;

        private static readonly Dictionary<DesktopMaterials, decimal> MaterialPrices = new Dictionary<DesktopMaterials, decimal>
    {
        { DesktopMaterials.Oak, 200m },
        { DesktopMaterials.Laminate, 100m },
        { DesktopMaterials.Pine, 50m },
        { DesktopMaterials.Rosewood, 300m },
        { DesktopMaterials.Veneer, 125m }
    };


        public DeskQuote(string customerName, Desk desk, string rushOrderOption, DateTime quoteDate)
        {
            CustomerName = customerName;
            Desk = desk;
            RushOrderOption = rushOrderOption;
            QuoteDate = quoteDate;
        }

        public decimal CalculateQuoteTotal()
        {
            decimal surfaceArea = Desk.Width * Desk.Depth;
            decimal surfaceAreaCost = surfaceArea > 1000 ? (surfaceArea - 1000) * PRICE_PER_SQUARE_INCH : 0;
            decimal drawerCost = Desk.NumberOfDrawers * PRICE_PER_DRAWER;
            decimal materialCost = MaterialPrices[Desk.Material];

            decimal rushOrderCost = CalculateRushOrderCost(surfaceArea);

            decimal quoteTotal = BASE_DESK_PRICE + surfaceAreaCost + drawerCost + materialCost + rushOrderCost;
            return quoteTotal;
        }

        private decimal CalculateRushOrderCost(decimal surfaceArea)
        {
            int[,] rushOrderPrices = new int[,]
            {
            { 60, 70, 80 },
            { 40, 50, 60 },
            { 30, 35, 40 }
            };

            int rushOrderIndex;
            if (RushOrderOption == "3")
                rushOrderIndex = 0;
            else if (RushOrderOption == "5")
                rushOrderIndex = 1;
            else if (RushOrderOption == "7")
                rushOrderIndex = 2;
            else
                return 0; // No rush order

            int sizeIndex;
            if (surfaceArea < 1000)
                sizeIndex = 0;
            else if (surfaceArea <= 2000)
                sizeIndex = 1;
            else
                sizeIndex = 2;

            return rushOrderPrices[rushOrderIndex, sizeIndex];
        }
    }
}
