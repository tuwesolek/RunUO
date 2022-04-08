using System;
using Server;

namespace Server.Items
{
    public class PasterzDuszPotepionych : WildStaff
    {
        
        public override int InitMinHits { get { return 60; } }
        public override int InitMaxHits { get { return 60; } }

        [Constructable]
        public PasterzDuszPotepionych()
        {
            Hue = 2919;
            Name = "Pasterz Dusz Potepionych";
            Attributes.WeaponDamage = 50;
            WeaponAttributes.HitLeechMana = 35;
            WeaponAttributes.HitMagicArrow = 40;
            Attributes.WeaponSpeed = 10;

            
            
        }

        public PasterzDuszPotepionych(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }
    }
}
