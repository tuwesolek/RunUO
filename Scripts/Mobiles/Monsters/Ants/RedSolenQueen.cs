using System;
using System.Collections;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "zwloki krolowej czerwonych mrowek" )]
	public class RedSolenQueen : BaseCreature
	{
		private bool m_BurstSac;
		public bool BurstSac{ get{ return m_BurstSac; } }

		[Constructable]
		public RedSolenQueen() : base( AIType.AI_Melee, FightMode.Closest, 12, 1, 0.2, 0.4 )
		{
			Name = "krolowa czerwonych mrowek";
			Body = 783;
			BaseSoundID = 959;

			SetStr( 296, 320 );
			SetDex( 121, 145 );
			SetInt( 76, 100 );

			SetHits( 151, 162 );

			SetDamage( 10, 15 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Poison, 30 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Fire, 30, 35 );
			SetResistance( ResistanceType.Cold, 25, 35 );
			SetResistance( ResistanceType.Poison, 35, 40 );
			SetResistance( ResistanceType.Energy, 25, 30 );

			SetSkill( SkillName.MagicResist, 70.0 );
			SetSkill( SkillName.Tactics, 90.0 );
			SetSkill( SkillName.Wrestling, 90.0 );

			Fame = 4500;
			Karma = -4500;

			VirtualArmor = 45;

			SolenHelper.PackPicnicBasket( this );

			PackItem( new ZoogiFungus( ( Utility.RandomDouble() > 0.05 )? 3 : 6 ) );

			if( Utility.RandomDouble() < 0.05 )
				PackItem( new BallOfSummoning() );
		}

		public override int GetAngerSound()
		{
			return 0x259;
		}

		public override int GetIdleSound()
		{
			return 0x259;
		}

		public override int GetAttackSound()
		{
			return 0x195;
		}

		public override int GetHurtSound()
		{
			return 0x250;
		}

		public override int GetDeathSound()
		{
			return 0x25B;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}


		public override bool IsEnemy( Mobile m )
		{
			if ( SolenHelper.CheckRedFriendship( m ) )
				return false;
			else
				return base.IsEnemy( m );
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			SolenHelper.OnRedDamage( from );

			if ( !willKill )
			{
				if ( !BurstSac )
				{
					if ( Hits < 50 )
					{
						PublicOverheadMessage( MessageType.Regular, 0x3B2, true, SolenAcidMsg );
						m_BurstSac = true;
					}
				}
				else if ( from != null && from != this && InRange( from, 1 ) )
				{
					SpillAcid( TimeSpan.FromSeconds( 10 ), from );
				}
			}

			base.OnDamage( amount, from, willKill );
		}

		public override bool OnBeforeDeath()
		{
			SpillAcid( TimeSpan.FromSeconds( 10 ), SolenAcidDmg, SolenAcidDmg, 1, 4 );

			return base.OnBeforeDeath();
		}

		public RedSolenQueen( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
			writer.Write( m_BurstSac );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			switch( version )
			{
				case 1:
				{
					m_BurstSac = reader.ReadBool();
					break;
				}
			}	
		}
	}
}