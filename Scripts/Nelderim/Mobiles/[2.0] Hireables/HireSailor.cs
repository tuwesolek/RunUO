using System; 
using System.Collections;
using System.Collections.Generic;
using Server.Items; 
using Server.ContextMenus; 
using Server.Misc; 
using Server.Network; 

namespace Server.Mobiles 
{ 
    public class HireSailor : BaseHire 
    { 
        [Constructable] 
        public HireSailor():  base( AIType.AI_Thief ) 
        { 
            SpeechHue = Utility.RandomDyedHue(); 
            Hue = Utility.RandomSkinHue(); 

            if ( this.Female = Utility.RandomBool() ) 
            { 
                Body = 0x191; 
                Name = NameList.RandomName( "female" ); 
              	AddItem( new ShortPants( Utility.RandomNeutralHue() ) ); 
            } 
            else 
            { 
                Body = 0x190; 
                Name = NameList.RandomName( "male" ); 
                AddItem( new ShortPants( Utility.RandomNeutralHue() ) ); 
            } 
		Title = "- żeglarz";
     
			
			Utility.AssignRandomHair( this );			
			
		

           	SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );

			SetHits( 298, 315 );

			SetDamage( 16, 22 );

            SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Poison, 30, 50 );
			SetResistance( ResistanceType.Energy, 30, 50 );			

            SetSkill( SkillName.Stealing, 66.0, 97.5 ); 
            SetSkill( SkillName.Peacemaking, 65.0, 87.5 ); 
            SetSkill( SkillName.MagicResist, 25.0, 47.5 ); 
            SetSkill( SkillName.Healing, 65.0, 87.5 ); 
            SetSkill( SkillName.Tactics, 65.0, 87.5 ); 
            SetSkill( SkillName.Fencing, 65.0, 87.5 ); 
            SetSkill( SkillName.Parry, 45.0, 60.5 ); 
		    SetSkill( SkillName.Lockpicking, 65, 87 );
		    SetSkill( SkillName.Hiding, 65, 87 );
		    SetSkill( SkillName.Snooping, 65, 87 );	
            Fame = 100; 
            Karma = 0; 

            AddItem( new Shoes( Utility.RandomNeutralHue() ) ); 
		AddItem( new Cutlass() );
		
		AddItem( new Shirt( Utility.RandomNeutralHue() ) );
		
		
            PackGold( 0, 25 ); 
        } 
	public override bool ClickTitle{ get{ return false; } }
        public HireSailor( Serial serial ) : base( serial ) 
        { 
        } 

        public override void Serialize( GenericWriter writer ) 
        { 
            base.Serialize( writer ); 

            writer.Write( (int) 0 ); // version 
        } 

        public override void Deserialize( GenericReader reader ) 
        { 
            base.Deserialize( reader ); 

            int version = reader.ReadInt(); 
        } 
    } 
} 
