// <auto-generated/>
// Contents of: hl7.fhir.r3.core version: 3.0.2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Validation;

/*
  Copyright (c) 2011+, HL7, Inc.
  All rights reserved.
  
  Redistribution and use in source and binary forms, with or without modification, 
  are permitted provided that the following conditions are met:
  
   * Redistributions of source code must retain the above copyright notice, this 
     list of conditions and the following disclaimer.
   * Redistributions in binary form must reproduce the above copyright notice, 
     this list of conditions and the following disclaimer in the documentation 
     and/or other materials provided with the distribution.
   * Neither the name of HL7 nor the names of its contributors may be used to 
     endorse or promote products derived from this software without specific 
     prior written permission.
  
  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
  IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
  POSSIBILITY OF SUCH DAMAGE.
  
*/

namespace Hl7.Fhir.Model
{
  /// <summary>
  /// A reply to an appointment request for a patient and/or practitioner(s), such as a confirmation or rejection
  /// </summary>
  [Serializable]
  [DataContract]
  [FhirType("AppointmentResponse","http://hl7.org/fhir/StructureDefinition/AppointmentResponse", IsResource=true)]
  public partial class AppointmentResponse : Hl7.Fhir.Model.DomainResource, IIdentifiable<List<Identifier>>
  {
    /// <summary>
    /// FHIR Type Name
    /// </summary>
    public override string TypeName { get { return "AppointmentResponse"; } }

    /// <summary>
    /// External Ids for this item
    /// </summary>
    [FhirElement("identifier", InSummary=true, Order=90, FiveWs="id")]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.Identifier> Identifier
    {
      get { if(_Identifier==null) _Identifier = new List<Hl7.Fhir.Model.Identifier>(); return _Identifier; }
      set { _Identifier = value; OnPropertyChanged("Identifier"); }
    }

    private List<Hl7.Fhir.Model.Identifier> _Identifier;

    /// <summary>
    /// Appointment this response relates to
    /// </summary>
    [FhirElement("appointment", InSummary=true, Order=100)]
    [CLSCompliant(false)]
    [References("Appointment")]
    [Cardinality(Min=1,Max=1)]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Appointment
    {
      get { return _Appointment; }
      set { _Appointment = value; OnPropertyChanged("Appointment"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Appointment;

    /// <summary>
    /// Time from appointment, or requested new start time
    /// </summary>
    [FhirElement("start", Order=110, FiveWs="when.init")]
    [DataMember]
    public Hl7.Fhir.Model.Instant StartElement
    {
      get { return _StartElement; }
      set { _StartElement = value; OnPropertyChanged("StartElement"); }
    }

    private Hl7.Fhir.Model.Instant _StartElement;

    /// <summary>
    /// Time from appointment, or requested new start time
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public DateTimeOffset? Start
    {
      get { return StartElement != null ? StartElement.Value : null; }
      set
      {
        if (value == null)
          StartElement = null;
        else
          StartElement = new Hl7.Fhir.Model.Instant(value);
        OnPropertyChanged("Start");
      }
    }

    /// <summary>
    /// Time from appointment, or requested new end time
    /// </summary>
    [FhirElement("end", Order=120, FiveWs="when.done")]
    [DataMember]
    public Hl7.Fhir.Model.Instant EndElement
    {
      get { return _EndElement; }
      set { _EndElement = value; OnPropertyChanged("EndElement"); }
    }

    private Hl7.Fhir.Model.Instant _EndElement;

    /// <summary>
    /// Time from appointment, or requested new end time
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public DateTimeOffset? End
    {
      get { return EndElement != null ? EndElement.Value : null; }
      set
      {
        if (value == null)
          EndElement = null;
        else
          EndElement = new Hl7.Fhir.Model.Instant(value);
        OnPropertyChanged("End");
      }
    }

    /// <summary>
    /// Role of participant in the appointment
    /// </summary>
    [FhirElement("participantType", InSummary=true, Order=130)]
    [Binding("ParticipantType")]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.CodeableConcept> ParticipantType
    {
      get { if(_ParticipantType==null) _ParticipantType = new List<Hl7.Fhir.Model.CodeableConcept>(); return _ParticipantType; }
      set { _ParticipantType = value; OnPropertyChanged("ParticipantType"); }
    }

    private List<Hl7.Fhir.Model.CodeableConcept> _ParticipantType;

    /// <summary>
    /// Person, Location/HealthcareService or Device
    /// </summary>
    [FhirElement("actor", InSummary=true, Order=140, FiveWs="who")]
    [CLSCompliant(false)]
    [References("Patient","Practitioner","RelatedPerson","Device","HealthcareService","Location")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Actor
    {
      get { return _Actor; }
      set { _Actor = value; OnPropertyChanged("Actor"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Actor;

    /// <summary>
    /// accepted | declined | tentative | in-process | completed | needs-action | entered-in-error
    /// </summary>
    [FhirElement("participantStatus", InSummary=true, IsModifier=true, Order=150)]
    [DeclaredType(Type = typeof(Code))]
    [Binding("ParticipantStatus")]
    [Cardinality(Min=1,Max=1)]
    [DataMember]
    public Code<Hl7.Fhir.Model.ParticipationStatus> ParticipantStatusElement
    {
      get { return _ParticipantStatusElement; }
      set { _ParticipantStatusElement = value; OnPropertyChanged("ParticipantStatusElement"); }
    }

    private Code<Hl7.Fhir.Model.ParticipationStatus> _ParticipantStatusElement;

    /// <summary>
    /// accepted | declined | tentative | in-process | completed | needs-action | entered-in-error
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public Hl7.Fhir.Model.ParticipationStatus? ParticipantStatus
    {
      get { return ParticipantStatusElement != null ? ParticipantStatusElement.Value : null; }
      set
      {
        if (value == null)
          ParticipantStatusElement = null;
        else
          ParticipantStatusElement = new Code<Hl7.Fhir.Model.ParticipationStatus>(value);
        OnPropertyChanged("ParticipantStatus");
      }
    }

    /// <summary>
    /// Additional comments
    /// </summary>
    [FhirElement("comment", Order=160)]
    [DataMember]
    public Hl7.Fhir.Model.FhirString CommentElement
    {
      get { return _CommentElement; }
      set { _CommentElement = value; OnPropertyChanged("CommentElement"); }
    }

    private Hl7.Fhir.Model.FhirString _CommentElement;

    /// <summary>
    /// Additional comments
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public string Comment
    {
      get { return CommentElement != null ? CommentElement.Value : null; }
      set
      {
        if (value == null)
          CommentElement = null;
        else
          CommentElement = new Hl7.Fhir.Model.FhirString(value);
        OnPropertyChanged("Comment");
      }
    }

    List<Identifier> IIdentifiable<List<Identifier>>.Identifier { get => Identifier; set => Identifier = value; }

    public override IDeepCopyable CopyTo(IDeepCopyable other)
    {
      var dest = other as AppointmentResponse;

      if (dest == null)
      {
        throw new ArgumentException("Can only copy to an object of the same type", "other");
      }

      base.CopyTo(dest);
      if(Identifier != null) dest.Identifier = new List<Hl7.Fhir.Model.Identifier>(Identifier.DeepCopy());
      if(Appointment != null) dest.Appointment = (Hl7.Fhir.Model.ResourceReference)Appointment.DeepCopy();
      if(StartElement != null) dest.StartElement = (Hl7.Fhir.Model.Instant)StartElement.DeepCopy();
      if(EndElement != null) dest.EndElement = (Hl7.Fhir.Model.Instant)EndElement.DeepCopy();
      if(ParticipantType != null) dest.ParticipantType = new List<Hl7.Fhir.Model.CodeableConcept>(ParticipantType.DeepCopy());
      if(Actor != null) dest.Actor = (Hl7.Fhir.Model.ResourceReference)Actor.DeepCopy();
      if(ParticipantStatusElement != null) dest.ParticipantStatusElement = (Code<Hl7.Fhir.Model.ParticipationStatus>)ParticipantStatusElement.DeepCopy();
      if(CommentElement != null) dest.CommentElement = (Hl7.Fhir.Model.FhirString)CommentElement.DeepCopy();
      return dest;
    }

    public override IDeepCopyable DeepCopy()
    {
      return CopyTo(new AppointmentResponse());
    }

    ///<inheritdoc />
    public override bool Matches(IDeepComparable other)
    {
      var otherT = other as AppointmentResponse;
      if(otherT == null) return false;

      if(!base.Matches(otherT)) return false;
      if( !DeepComparable.Matches(Identifier, otherT.Identifier)) return false;
      if( !DeepComparable.Matches(Appointment, otherT.Appointment)) return false;
      if( !DeepComparable.Matches(StartElement, otherT.StartElement)) return false;
      if( !DeepComparable.Matches(EndElement, otherT.EndElement)) return false;
      if( !DeepComparable.Matches(ParticipantType, otherT.ParticipantType)) return false;
      if( !DeepComparable.Matches(Actor, otherT.Actor)) return false;
      if( !DeepComparable.Matches(ParticipantStatusElement, otherT.ParticipantStatusElement)) return false;
      if( !DeepComparable.Matches(CommentElement, otherT.CommentElement)) return false;

      return true;
    }

    public override bool IsExactly(IDeepComparable other)
    {
      var otherT = other as AppointmentResponse;
      if(otherT == null) return false;

      if(!base.IsExactly(otherT)) return false;
      if( !DeepComparable.IsExactly(Identifier, otherT.Identifier)) return false;
      if( !DeepComparable.IsExactly(Appointment, otherT.Appointment)) return false;
      if( !DeepComparable.IsExactly(StartElement, otherT.StartElement)) return false;
      if( !DeepComparable.IsExactly(EndElement, otherT.EndElement)) return false;
      if( !DeepComparable.IsExactly(ParticipantType, otherT.ParticipantType)) return false;
      if( !DeepComparable.IsExactly(Actor, otherT.Actor)) return false;
      if( !DeepComparable.IsExactly(ParticipantStatusElement, otherT.ParticipantStatusElement)) return false;
      if( !DeepComparable.IsExactly(CommentElement, otherT.CommentElement)) return false;

      return true;
    }

    [IgnoreDataMember]
    public override IEnumerable<Base> Children
    {
      get
      {
        foreach (var item in base.Children) yield return item;
        foreach (var elem in Identifier) { if (elem != null) yield return elem; }
        if (Appointment != null) yield return Appointment;
        if (StartElement != null) yield return StartElement;
        if (EndElement != null) yield return EndElement;
        foreach (var elem in ParticipantType) { if (elem != null) yield return elem; }
        if (Actor != null) yield return Actor;
        if (ParticipantStatusElement != null) yield return ParticipantStatusElement;
        if (CommentElement != null) yield return CommentElement;
      }
    }

    [IgnoreDataMember]
    public override IEnumerable<ElementValue> NamedChildren
    {
      get
      {
        foreach (var item in base.NamedChildren) yield return item;
        foreach (var elem in Identifier) { if (elem != null) yield return new ElementValue("identifier", elem); }
        if (Appointment != null) yield return new ElementValue("appointment", Appointment);
        if (StartElement != null) yield return new ElementValue("start", StartElement);
        if (EndElement != null) yield return new ElementValue("end", EndElement);
        foreach (var elem in ParticipantType) { if (elem != null) yield return new ElementValue("participantType", elem); }
        if (Actor != null) yield return new ElementValue("actor", Actor);
        if (ParticipantStatusElement != null) yield return new ElementValue("participantStatus", ParticipantStatusElement);
        if (CommentElement != null) yield return new ElementValue("comment", CommentElement);
      }
    }

    protected override bool TryGetValue(string key, out object value)
    {
      switch (key)
      {
        case "identifier":
          value = Identifier;
          return Identifier?.Any() == true;
        case "appointment":
          value = Appointment;
          return Appointment is not null;
        case "start":
          value = StartElement;
          return StartElement is not null;
        case "end":
          value = EndElement;
          return EndElement is not null;
        case "participantType":
          value = ParticipantType;
          return ParticipantType?.Any() == true;
        case "actor":
          value = Actor;
          return Actor is not null;
        case "participantStatus":
          value = ParticipantStatusElement;
          return ParticipantStatusElement is not null;
        case "comment":
          value = CommentElement;
          return CommentElement is not null;
        default:
          return base.TryGetValue(key, out value);
      }

    }

    protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
    {
      foreach (var kvp in base.GetElementPairs()) yield return kvp;
      if (Identifier?.Any() == true) yield return new KeyValuePair<string,object>("identifier",Identifier);
      if (Appointment is not null) yield return new KeyValuePair<string,object>("appointment",Appointment);
      if (StartElement is not null) yield return new KeyValuePair<string,object>("start",StartElement);
      if (EndElement is not null) yield return new KeyValuePair<string,object>("end",EndElement);
      if (ParticipantType?.Any() == true) yield return new KeyValuePair<string,object>("participantType",ParticipantType);
      if (Actor is not null) yield return new KeyValuePair<string,object>("actor",Actor);
      if (ParticipantStatusElement is not null) yield return new KeyValuePair<string,object>("participantStatus",ParticipantStatusElement);
      if (CommentElement is not null) yield return new KeyValuePair<string,object>("comment",CommentElement);
    }

  }

}

// end of file
