#region ENBREA UNTIS.GPU - Copyright (C) 2021 STÜBER SYSTEMS GmbH
/*    
 *    ENBREA UNTIS.GPU 
 *    
 *    Copyright (C) 2021 STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

using System;

namespace Enbrea.Untis.Gpu
{
    [Flags]
    public enum GpuSubstitutionFlags
    {
        Cancellation = 0x0,            // Bit  0 = Entfall
        Supervision = 0x1,             // Bit  1 = Betreuung
        SpecialDuty = 0x2,             // Bit  2 = Sondereinsatz
        ShiftedFrom = 0x4,             // Bit  3 = Wegverlegung
        Release = 0x8,                 // Bit  4 = Freisetzung
        PlusAsStandIn = 0x10,          // Bit  5 = Plus als Vertreter
        PartialStandIn = 0x20,         // Bit  6 = Teilvertretung
        ShiftedTo = 0x40,              // Bit  7 = Hinverlegung
        RoomExchange = 0x8000,         // Bit 16 = Raumvertretung
        SupervisionExchange = 0x10000, // Bit 17 = Pausenaufsichtsvertretung
        NoLesson = 0x20000,            // Bit 18 = Stunde ist unterrichtsfrei
        DoNotPrintFlag = 0x80000,      // Bit 20 = Kennzeichen nicht drucken
        NewFlag = 0x1000000            // Bit 21 = Kennzeichen neu
    }
}
