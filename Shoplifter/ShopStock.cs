﻿using System;
using StardewValley.Objects;
using System.Collections;
using System.Collections.Generic;
using StardewValley.Locations;
using StardewValley;
using System.Linq;
using StardewModdingAPI;
using StardewValley.GameData.Shops;
using StardewValley.GameData.Crops;
using StardewValley.Internal;

namespace Shoplifter
{	
	public class ShopStock
	{
		public static ArrayList CurrentStock = new ArrayList();

        /// <summary>
        /// Generates a random list of stock for the given shop
        /// </summary>
        /// <param name="maxstock">The maximum number of different stock items to generate</param>
        /// <param name="maxquantity">The maximum quantity of each stock</param>
        /// <param name="which">The shop to generate stock for</param>
        /// <returns>The generated stock list</returns>
        public static List<ISalable> generateRandomStock(int maxstock, int maxquantity, string which)
		{
            //if (!System.Diagnostics.Debugger.IsAttached) { System.Diagnostics.Debugger.Launch(); }
            GameLocation location = Game1.currentLocation;
            List<ISalable> stock = new List<ISalable>();
			Random random = new Random((int)Game1.uniqueIDForThisGame / 2 + (int)Game1.stats.DaysPlayed + ModEntry.PerScreenShopliftCounter.Value);
			int stocklimit = random.Next(1, maxstock + 1);
			string index;
            var shopstock = ShopBuilder.GetShopStock(which);


			switch (which)
            {
                // Pierre's shop
				case "SeedShop":
                    foreach (var stockinfo in shopstock)
                    {
                        if ((stockinfo.Key as StardewValley.Object) == null || (stockinfo.Key as StardewValley.Object).QualifiedItemId.StartsWith("(O)") == false || (stockinfo.Key as StardewValley.Object).IsRecipe == true)
                        {
                            continue;
                        }

                        // Add object id to array
                        if ((stockinfo.Key as StardewValley.Object) != null && (stockinfo.Key as StardewValley.Object).bigCraftable.Value == false)
                        {
                            if (ModEntry.IDGAItem?.GetDGAItemId(stockinfo.Key as StardewValley.Object) != null)
                            {
                                var id = ModEntry.IDGAItem.GetDGAItemId(stockinfo.Key as StardewValley.Object);

                                CurrentStock.Add(id);
                            }

                            else
                            {
                                index = (stockinfo.Key as StardewValley.Object).QualifiedItemId;

                                CurrentStock.Add(index);
                            }
                        }
                    }

                    // Grass starter if nothing available
                    if (CurrentStock.Count == 0)
                    {
                        CurrentStock.Add("(O)297");
                    }
                    break;

				// Willy's shop
				case "FishShop":
                    foreach (var stockinfo in shopstock)
                    {
                        if ((stockinfo.Key as StardewValley.Object) == null || (stockinfo.Key as StardewValley.Object).QualifiedItemId.StartsWith("(O)") == false || (stockinfo.Key as StardewValley.Object).IsRecipe == true)
                        {
                            continue;
                        }

                        // Add object id to array
                        if ((stockinfo.Key as StardewValley.Object) != null && (stockinfo.Key as StardewValley.Object).bigCraftable.Value == false)
                        {
                            if (ModEntry.IDGAItem?.GetDGAItemId(stockinfo.Key as StardewValley.Object) != null)
                            {
                                var id = ModEntry.IDGAItem.GetDGAItemId(stockinfo.Key as StardewValley.Object);

                                CurrentStock.Add(id);
                            }

                            else
                            {
                                index = (stockinfo.Key as StardewValley.Object).QualifiedItemId;

                                CurrentStock.Add(index);
                            }
                        }
                    }

                    // Trout soup if nothing available
                    if (CurrentStock.Count == 0)
                    {
                        CurrentStock.Add("(O)219");
                    }
                    break;

				// Robin's shop
				case "Carpenter":
                    foreach (var stockinfo in shopstock)
                    {
                        if ((stockinfo.Key as StardewValley.Object) == null || (stockinfo.Key as StardewValley.Object).QualifiedItemId.StartsWith("(O)") == false || (stockinfo.Key as StardewValley.Object).IsRecipe == true)
                        {
                            continue;
                        }

                        // Add object id to array
                        if ((stockinfo.Key as StardewValley.Object) != null && (stockinfo.Key as StardewValley.Object).bigCraftable.Value == false)
                        {
                            if (ModEntry.IDGAItem?.GetDGAItemId(stockinfo.Key as StardewValley.Object) != null)
                            {
                                var id = ModEntry.IDGAItem.GetDGAItemId(stockinfo.Key as StardewValley.Object);

                                CurrentStock.Add(id);
                            }

                            else
                            {
                                index = (stockinfo.Key as StardewValley.Object).QualifiedItemId;

                                CurrentStock.Add(index);
                            }
                        }
                    }
                    // Wood if nothing available
                    if (CurrentStock.Count == 0)
                    {
                        CurrentStock.Add("(O)388");
                    }
                    break;

				// Marnie's shop
				case "AnimalShop":
                    foreach (var stockinfo in shopstock)
                    {
                        if ((stockinfo.Key as StardewValley.Object) == null || (stockinfo.Key as StardewValley.Object).QualifiedItemId.StartsWith("(O)") == false || (stockinfo.Key as StardewValley.Object).IsRecipe == true)
                        {
                            continue;
                        }

                        // Add object id to array
                        if ((stockinfo.Key as StardewValley.Object) != null && (stockinfo.Key as StardewValley.Object).bigCraftable.Value == false)
                        {
                            if (ModEntry.IDGAItem?.GetDGAItemId(stockinfo.Key as StardewValley.Object) != null)
                            {
                                var id = ModEntry.IDGAItem.GetDGAItemId(stockinfo.Key as StardewValley.Object);

                                CurrentStock.Add(id);
                            }

                            else
                            {
                                index = (stockinfo.Key as StardewValley.Object).QualifiedItemId;

                                CurrentStock.Add(index);
                            }
                        }
                    }
                    // Hay if nothing available
                    if (CurrentStock.Count == 0)
                    {
                        CurrentStock.Add("(O)178");
                    }
                    break;

				// Clint's shop
				case "Blacksmith":
                    foreach (var stockinfo in shopstock)
                    {
                        if ((stockinfo.Key as StardewValley.Object) == null || (stockinfo.Key as StardewValley.Object).QualifiedItemId.StartsWith("(O)") == false || (stockinfo.Key as StardewValley.Object).IsRecipe == true)
                        {
                            continue;
                        }

                        // Add object id to array
                        if ((stockinfo.Key as StardewValley.Object) != null && (stockinfo.Key as StardewValley.Object).bigCraftable.Value == false)
                        {
                            if (ModEntry.IDGAItem?.GetDGAItemId(stockinfo.Key as StardewValley.Object) != null)
                            {
                                var id = ModEntry.IDGAItem.GetDGAItemId(stockinfo.Key as StardewValley.Object);

                                CurrentStock.Add(id);
                            }

                            else
                            {
                                index = (stockinfo.Key as StardewValley.Object).QualifiedItemId;

                                CurrentStock.Add(index);
                            }
                        }
                    }
                    // Coal if nothing available
                    if (CurrentStock.Count == 0)
                    {
                        CurrentStock.Add("(O)382");
                    }
                    break;

				// Gus' shop
				case "Saloon":
                    foreach (var stockinfo in shopstock)
                    {
                        if ((stockinfo.Key as StardewValley.Object) == null || (stockinfo.Key as StardewValley.Object).QualifiedItemId.StartsWith("(O)") == false || (stockinfo.Key as StardewValley.Object).IsRecipe == true)
                        {
                            continue;
                        }

                        // Add object id to array
                        if ((stockinfo.Key as StardewValley.Object) != null && (stockinfo.Key as StardewValley.Object).bigCraftable.Value == false)
                        {
                            if (ModEntry.IDGAItem?.GetDGAItemId(stockinfo.Key as StardewValley.Object) != null)
                            {
                                var id = ModEntry.IDGAItem.GetDGAItemId(stockinfo.Key as StardewValley.Object);

                                CurrentStock.Add(id);
                            }

                            else
                            {
                                index = (stockinfo.Key as StardewValley.Object).QualifiedItemId;

                                CurrentStock.Add(index);
                            }
                        }
                    }
                    // Beer if nothing available
                    if (CurrentStock.Count == 0)
                    {
                        CurrentStock.Add("(O)346");
                    }
                    break;

				// Harvey's shop
				case "Hospital":
                    foreach (var stockinfo in shopstock)
                    {
                        if ((stockinfo.Key as StardewValley.Object) == null || (stockinfo.Key as StardewValley.Object).QualifiedItemId.StartsWith("(O)") == false || (stockinfo.Key as StardewValley.Object).IsRecipe == true)
                        {
                            continue;
                        }

                        // Add object id to array
                        if ((stockinfo.Key as StardewValley.Object) != null && (stockinfo.Key as StardewValley.Object).bigCraftable.Value == false)
                        {
                            if (ModEntry.IDGAItem?.GetDGAItemId(stockinfo.Key as StardewValley.Object) != null)
                            {
                                var id = ModEntry.IDGAItem.GetDGAItemId(stockinfo.Key as StardewValley.Object);

                                CurrentStock.Add(id);
                            }

                            else
                            {
                                index = (stockinfo.Key as StardewValley.Object).QualifiedItemId;

                                CurrentStock.Add(index);
                            }
                        }
                    }
                    // Muscle Remedy if nothing available
                    if (CurrentStock.Count == 0)
                    {
                        CurrentStock.Add("(O)351");
                    }
                    break;
				// Icecream Stand
				case "IceCreamStand":
					CurrentStock.Add("(O)233");
                    break;

				// Sandy's shop
				case "Sandy":

                    // Add object id to array
                    CurrentStock.Add("(O)802");
                    CurrentStock.Add("(O)478");
                    CurrentStock.Add("(O)486");
                    CurrentStock.Add("(O)494");

                    switch (Game1.dayOfMonth % 7)
                    {
                        case 0:
                            CurrentStock.Add("(O)233");
                            break;
                        case 1:
                            CurrentStock.Add("(O)88");
                            break;
                        case 2:
                            CurrentStock.Add("(O)90");
                            break;
                        case 3:
                            CurrentStock.Add("(O)749");
                            break;
                        case 4:
                            CurrentStock.Add("(O)466");
                            break;
                        case 5:
                            CurrentStock.Add("(O)340");
                            break;
                        case 6:
                            CurrentStock.Add("(O)371");
                            break;
                    }
                    break;
				default:
					CurrentStock.Add("(O)340");
					break;
			}
			
			// Add generated stock to store from array
			for (int i = 0; i < stocklimit; i++)
			{
                int quantity = random.Next(1, maxquantity + 1);
				var itemindex = random.Next(0, CurrentStock.Count);

				if (CurrentStock.Count == 0)
				{
					break;
				}

				//if (CurrentStock[itemindex] is String && ModEntry.IDGAItem.SpawnDGAItem(CurrentStock[itemindex].ToString()) as StardewValley.ISalable as Item != null)
				//{
				//	var dgaitem = (ModEntry.IDGAItem.SpawnDGAItem(CurrentStock[itemindex].ToString()) as StardewValley.ISalable) as Item;
				//	dgaitem.Stack = quantity;
    //                stock.Add(dgaitem);
    //                //Utility.AddStock(stock, dgaitem, 0, quantity);
				//	CurrentStock.RemoveAt(itemindex);
				//	continue;
				//}

                var itemtoadd = CurrentStock[itemindex].ToString();
                var item = new StardewValley.Object(itemtoadd, quantity,false,0,0);
                stock.Add(item);
                CurrentStock.RemoveAt(itemindex);
            }

			// Clear stock array
			CurrentStock.Clear();

			return stock;
		}
	}
}