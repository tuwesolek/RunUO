using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "zwloki lorda juka" )] // Why is this 'juka' and warriors 'jukan' ? :-(
	public class JukaLord : BaseCreature
	{
		[Constructable]
		public JukaLord() : base( AIType.AI_Archer, FightMode.Closest, 12, 3, 0.2, 0.4 )
		{
			Name = "lord juka";
			Body = 766;

			SetStr( 401, 500 );
			SetDex( 81, 100 );
			SetInt( 151, 200 );

			SetHits( 241, 300 );

			SetDamage( 10, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 45, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 20, 25 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Anatomy, 90.1, 100.0 );
			SetSkill( SkillName.Archery, 95.1, 100.0 );
			SetSkill( SkillName.Healing, 80.1, 100.0 );
			SetSkill( SkillName.MagicResist, 120.1, 130.0 );
			SetSkill( SkillName.Swords, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 95.1, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 28;

			Container pack = new Backpack();

			pack.DropItem( new Arrow( Utility.RandomMinMax( 15, 25 ) ) );
			pack.DropItem( new Arrow( Utility.RandomMinMax( 15, 25 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( Loot.RandomGem() );
			pack.DropItem( new ArcaneGem() );

			PackItem( pack );

			AddItem( new JukaBow() );

			// TODO: Bandage self
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
				if ( Utility.RandomDouble() < 0.3 )
				PackItem( new BowstringSilk() );
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( from != null && !willKill && amount > 5 && from.Player && 5 > Utility.Random( 100 ) )
			{
				string[] toSay = new string[]
					{
						"{0}!!  Musisz byc nieco lepszy niz to co prezentujesz!",
						"{0}!!  Przygotuj sie na spotkanie z twoim stworca!",
						"{0}!!  Moje armie was zniszcza!",
						"{0}!!  Zaplacisz za to, krasnoludzka moneta!"
					};

				this.Say( true, String.Format( toSay[Utility.Random( toSay.Length )], from.Name ) );
			}

			base.OnDamage( amount, from, willKill );
		}

		public override int GetIdleSound()
		{
			return 0x262;
		}

		public override int GetAngerSound()
		{
			return 0x263;
		}

		public override int GetHurtSound()
		{
			return 0x1D0;
		}

		public override int GetDeathSound()
		{
			return 0x28D;
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public JukaLord( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
