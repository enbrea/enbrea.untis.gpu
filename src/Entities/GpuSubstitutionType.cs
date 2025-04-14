#region ENBREA UNTIS.GPU - Copyright (C) STÜBER SYSTEMS GmbH
/*    
 *    ENBREA UNTIS.GPU 
 *    
 *    Copyright (C) STÜBER SYSTEMS GmbH
 *
 *    Licensed under the MIT License, Version 2.0. 
 * 
 */
#endregion

namespace Enbrea.Untis.Gpu
{
    public enum GpuSubstitutionType
    {
        ShiftedTo,               // T = verlegt
        ShiftedFrom,             // F = verlegt von
        Exchange,                // W = Tausch
        Supervision,             // S = Betreuung
        SpecialOccurrence,       // A = Sondereinsatz
        Cancellation,            // C = Entfall
        Exemption,               // L = Freisetzung
        PartialExchange,         // P = Teilvertretung
        RoomExchange,            // R = Raumvertretung
        BreakSupervisionStandIn, // B = Pausenaufsichtsvertretung
        TeacherExchange,         // ~ = Lehrertausch
        Exam                     // E = Klausur
    }
}
