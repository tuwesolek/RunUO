using System;
using Server.Network;
using Server;
using Server.Targets;
using Server.Targeting;
using Server.Spells;
using Server.Mobiles;

namespace Server.Items
{
	public class EarthElementalPotion : BaseElementalPotion
	{
		private static Type m_CreatureType = typeof(SummonedEarthElemental);

		private static int[] m_LandTiles = new int[] {
			0x0009, 0x000A,
			0x000C, 0x000B,
			0x000D, 0x0072,
			0x000E, 0x000F,
			0x0010, 0x0011,
			0x0012, 0x0013,
			0x0014, 0x0015,
			0x004C, 0x0071,
			0x0073, 0x0074,
			0x0075, 0x0076,
			0x0077, 0x0078,
			0x007A, 0x007B,
			0x007C, 0x007D,
			0x007E, 0x31F,
			0x014E, 0x014F,
			0x0150, 0x0151,
			0x0152, 0x0153,
			0x0154, 0x0155,
			0x0156, 0x0157,
			0x0158, 0x0159,
			0x015A, 0x015B,
			0x015C, 0x015E,
			0x015F, 0x0160,
			0x0161, 0x0162,
			0x0163, 0x0164,
			0x0165, 0x0166,
			0x0167, 0x0168,
			0x0169, 0x016A,
			0x016B, 0x016C,
			0x016D, 0x016E,
			0x016F, 0x0170,
			0x0171, 0x0172,
			0x0173, 0x0174,
			0x027E, 0x027F,
			0x0280, 0x0281,
			0x0355, 0x0356,
			0x0357, 0x3558,
			0x0377, 0x37A,
			0x0553, 0x0554,
			0x0555, 0x0556,
			0x07AE, 0x07AF,
			0x07B1, 0x7B2,
		};

		private static int[] m_ItemIDs = new int[] {
			0x0911, 0x0914,
			0x1B27, 0x1B3E,
			0x31F4, 0x31FB,
			0x32C9, 0x32CA,
			0x3573, 0x357E,
			0x35AE, 0x35B1,
			0xF81
		};

		public override Type CreatureType { get { return m_CreatureType; } }

		public override int[] LandTiles
		{
			get
			{
				return m_LandTiles;
			}
		}

		public override int[] ItemIDs
		{
			get
			{
				return m_ItemIDs;
			}
		}

		[Constructable]
		public EarthElementalPotion()
			: base(PotionEffect.EarthElemental)
		{
			Weight = 0.5;
			Movable = true;
			Hue = 143;
			Name = "Mikstura Zywiolaka Ziemi";
		}

		public EarthElementalPotion(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

}
/*
		public static bool IsDirtPatch(object obj)
		{
			int tileID;

			if (obj is Static && !((Static)obj).Movable)
				tileID = (((Static)obj).ItemID & 0x3FFF) | 0x4000;
			else if (obj is StaticTarget)
				tileID = (((StaticTarget)obj).ItemID & 0x3FFF) | 0x4000;
			else if (obj is LandTarget)
				tileID = ((LandTarget)obj).TileID & 0x3FFF;
			else
				return false;

			bool contains = false;

			for (int i = 0; !contains && i < m_DirtPatchTiles.Length; i += 2)
				contains = (tileID >= m_DirtPatchTiles[i] && tileID <= m_DirtPatchTiles[i + 1]);

			return contains;
		}

		private static int[] m_DirtPatchTiles = new int[]
			{
				0x9, 0x15,
				0x71, 0x7C,
				0x82, 0xA7,
				0xDC, 0xE3,
				0xE8, 0xEB,
				0x141, 0x144,
				0x14C, 0x15C,
				0x169, 0x174,
				0x1DC, 0x1EF,
				0x272, 0x275,
				0x27E, 0x281,
				0x2D0, 0x2D7,
				0x2E5, 0x2FF,
				0x303, 0x31F,
				0x32C, 0x32F,
				0x33D, 0x340,
				0x345, 0x34C,
				0x355, 0x358,
				0x367, 0x36E,
				0x377, 0x37A,
				0x38D, 0x390,
				0x395, 0x39C,
				0x3A5, 0x3A8,
				0x3F6, 0x405,
				0x547, 0x54E,
				0x553, 0x556,
				0x597, 0x59E,
				0x623, 0x63A,
				0x6F3, 0x6FA,
				0x777, 0x791,
				0x79A, 0x7A9,
				0x7AE, 0x7B1,
				0x98C, 0x99F,
				0x9AC, 0x9BF,
				0x5B27, 0x5B3E,
				0x71F4, 0x71FB,
				0x72C9, 0x72CA,
			};

*/