# Creating Content Packs for Shoplifter

Content Packs can be created to allow for custom shops added using Content Patcher to be made shopliftable. Content Packs for Shoplifter require two files, a ``manifest.json`` and a ``shopliftables.json``. See [placeholder] for a full example ``shopliftables.json``.

## manifest.json
The ``manifest.json`` tells SMAPI that your content pack is readable by Shoplifter, it is similar in format to other Content Pack manifest files. However, in the ``ContentPackFor`` section the ``UniqueID`` should have the value of ``TheMightyAmondee.Shoplifter``.

## shopliftables.json
The ``shopliftables.json`` is the important one. Here, new shopliftable shops are defined. The ``shopliftables.json`` is made up of a list of ``MakeShopliftable``s where shopliftable shops are defined.

Each entry in ``MakeShopliftable`` has a few required and non-required fields, see below!

Field | Type | Required? | What it does | Notes
------|------|-----------|--------------|------
UniqueShopId | string | Yes | A unique identifier for the shop, anything unique will do! | -
ShopName | string | Yes | The id of the shop, as defined by the game in Data\Shops or by a custom shop, the mod uses this to get available stock | -
CounterLocation | ``ShopCounterLocation`` | Yes | Where the counter for the shop is located (the tile location to click on to open the store) | See ShopCounterLocation model below
ShopKeepers | List<string> | Yes | A list of all the shopkeepers' names (anyone who can catch, fine and/or ban the player) | -
CaughtDialogue |  Dictionary<string, string> | No | Unique dialogue for the shopkeeper to say when the player is caught. | See Unique Dialogue below
OpenConditions | ``ShopliftableConditions`` | No | Under what conditions the store is normally open and items can be purchased | See ShopliftableConditions model below
MaxStockQuantity | int | No | The maximum number of different stock items that can appear in each shoplift attempt | Default value is 1
MaxStackPerItem | int | No | The maximum stack size of each stock item | Default value is 1
Bannable | bool | No | Whether the player can be banned from the shop | Default value is false. I wouldn't recommend outdoor shops be bannable, since players will no longer be able to enter that outdoor area if banned.

## ShopCounterLocation model
This model describes where the store is located (what tile of what map must be clicked on to open the store)

Field | Type | Required? | What it does | Notes
------|------|-----------|--------------|------
LocationName | string | Yes | The location name where the shop is located | This is also the location the player won't be able to enter if banned.
TileX | int | No | The X tile coordinate of the shop counter | Default is 0 if not specified
TileY | int | No | The Y tile coordinate of the shop counter | Default is 0 if not specified

## ShopliftableConditions model
This model describes when the store is normally open. 
If any named condition is false the shop will be considered shopliftable.

Field | Type | Required? | What it does | Notes
------|------|-----------|--------------|------
OpenTime | int | No | The time the store opens | Defaults to no open time (open first thing in the morning)
CloseTime | int | No | The time the store closes | Defaults to no close time (shop won't close during the day)
Weather | List<string> | No | Under what weather conditions the store is open | By default store is considered open in all weather conditions
Season | List<string> | No | What seasons the store is open | By default store is considered open in all seasons
DayOfSeason | List<int> | No | What days of the season the store is open | By default store is considered open all days
EventsSeen | List<string> | No | The ids of the events that must have been seen for the store to open | All listed event ids must be seen for the store to be considered open
FriendshipLevels | Dictionary<string,int> | No | The minimum friendship level for each named npc needed for the store to open | In the form "npcname" : 0, all friendship levels listed must be above their respective minimum for the store to be considered open
ShopKeeperRange | List<``ShopKeeperConditions``> | No | The defined range each shopkeeper must be within the store for it to be considered open | See ShopKeeperConditions model below

Any conditions not defined will not count towards determining shop accessibility. In the case of time, both OpenTime and CloseTime must be undefined.
If no conditions are defined, shop is considered always open and not shopliftable (not very useful).

## ShopKeeperConditions model
This model describes when shopkeepers are present at the store (in other words, able to sell items).
Fields describe a rectangle area on the map that the named shopkeeper must be present in for the shop to be accessible. This would generally be the tile behind the shop counter, but can be anything you want.

Field | Type | Required? | What it does | Notes
------|------|-----------|--------------|------
Name | string | Yes | The name of the shopkeeper | -
TileX | int | Yes | The X tile coordinate of the upper left rectangle point | -
TileY | int | Yes | The Y tile coordinate of the upper left rectangle point | -
Width | int | No | The width of the rectangle the shopkeeper must be within | Default is 1
Height | int | No | The height of the rectangle the shopkeeper must be within | Default is 1

## Unique Dialogue
Shopkeepers can be given unique dialogue to say when the player is caught shoplifting using ``CaughtDialogue``. Each shopkeeper can have two different entries, one for when the player is fined, and one for when the player cannot afford the fine. Both, either or none may be specified. Shopkeepers will use generic dialogue if the appropriate dialogue is not defined.

Each entry in ``UniqueDialogue`` is in the form of a key value pair ("key" : "value") with entries separated by a comma. 
The key should be the name of the shopkeeper (dialogue when fined) or in the form "[shopkeepername]_NoMoney" (dialogue when not fined).
The value should be the dialogue for the shopkeeper to say. In the case of dialogue for when the player is fined, the text {0} will be replaced with the fine amount.
Dialogue replacers and commands will also work e.g @ being replaced with the farmer's name.

See below for an example which gives Harvey unique caught dialogue in both cases:
``"CaughtDialogue": { "Harvey" : "I'm fining you {0}g for this @.", "Harvey_NoMoney" : "You can't afford a fine right now." }``