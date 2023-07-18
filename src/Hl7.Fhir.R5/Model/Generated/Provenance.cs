// <auto-generated/>
// Contents of: hl7.fhir.r5.core version: 5.0.0

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
  /// Who, What, When for a set of resources
  /// </summary>
  [Serializable]
  [DataContract]
  [FhirType("Provenance","http://hl7.org/fhir/StructureDefinition/Provenance", IsResource=true)]
  public partial class Provenance : Hl7.Fhir.Model.DomainResource
  {
    /// <summary>
    /// FHIR Type Name
    /// </summary>
    public override string TypeName { get { return "Provenance"; } }

    /// <summary>
    /// How an entity was used in an activity.
    /// (url: http://hl7.org/fhir/ValueSet/provenance-entity-role)
    /// (system: http://hl7.org/fhir/provenance-entity-role)
    /// </summary>
    [FhirEnumeration("ProvenanceEntityRole", "http://hl7.org/fhir/ValueSet/provenance-entity-role", "http://hl7.org/fhir/provenance-entity-role")]
    public enum ProvenanceEntityRole
    {
      /// <summary>
      /// An entity that is used by the activity to produce a new version of that entity.
      /// (system: http://hl7.org/fhir/provenance-entity-role)
      /// </summary>
      [EnumLiteral("revision"), Description("Revision")]
      Revision,
      /// <summary>
      /// An entity that is copied in full or part by an agent that is not the author of the entity.
      /// (system: http://hl7.org/fhir/provenance-entity-role)
      /// </summary>
      [EnumLiteral("quotation"), Description("Quotation")]
      Quotation,
      /// <summary>
      /// An entity that is used as input to the activity that produced the target.
      /// (system: http://hl7.org/fhir/provenance-entity-role)
      /// </summary>
      [EnumLiteral("source"), Description("Source")]
      Source,
      /// <summary>
      /// The record resulting from this event adheres to the protocol, guideline, order set or other definition represented by this entity.
      /// (system: http://hl7.org/fhir/provenance-entity-role)
      /// </summary>
      [EnumLiteral("instantiates"), Description("Instantiates")]
      Instantiates,
      /// <summary>
      /// An entity that is removed from accessibility, usually through the DELETE operator.
      /// (system: http://hl7.org/fhir/provenance-entity-role)
      /// </summary>
      [EnumLiteral("removal"), Description("Removal")]
      Removal,
    }

    /// <summary>
    /// Actor involved
    /// </summary>
    [Serializable]
    [DataContract]
    [FhirType("Provenance#Agent", IsNestedType=true)]
    [BackboneType("Provenance.agent")]
    public partial class AgentComponent : Hl7.Fhir.Model.BackboneElement
    {
      /// <summary>
      /// FHIR Type Name
      /// </summary>
      public override string TypeName { get { return "Provenance#Agent"; } }

      /// <summary>
      /// How the agent participated
      /// </summary>
      [FhirElement("type", InSummary=true, Order=40)]
      [Binding("ProvenanceAgentType")]
      [DataMember]
      public Hl7.Fhir.Model.CodeableConcept Type
      {
        get { return _Type; }
        set { _Type = value; OnPropertyChanged("Type"); }
      }

      private Hl7.Fhir.Model.CodeableConcept _Type;

      /// <summary>
      /// What the agents role was
      /// </summary>
      [FhirElement("role", Order=50)]
      [Binding("ProvenanceAgentRole")]
      [Cardinality(Min=0,Max=-1)]
      [DataMember]
      public List<Hl7.Fhir.Model.CodeableConcept> Role
      {
        get { if(_Role==null) _Role = new List<Hl7.Fhir.Model.CodeableConcept>(); return _Role; }
        set { _Role = value; OnPropertyChanged("Role"); }
      }

      private List<Hl7.Fhir.Model.CodeableConcept> _Role;

      /// <summary>
      /// The agent that participated in the event
      /// </summary>
      [FhirElement("who", InSummary=true, Order=60, FiveWs="FiveWs.actor")]
      [CLSCompliant(false)]
      [References("Practitioner","PractitionerRole","Organization","CareTeam","Patient","Device","RelatedPerson")]
      [Cardinality(Min=1,Max=1)]
      [DataMember]
      public Hl7.Fhir.Model.ResourceReference Who
      {
        get { return _Who; }
        set { _Who = value; OnPropertyChanged("Who"); }
      }

      private Hl7.Fhir.Model.ResourceReference _Who;

      /// <summary>
      /// The agent that delegated
      /// </summary>
      [FhirElement("onBehalfOf", Order=70)]
      [CLSCompliant(false)]
      [References("Practitioner","PractitionerRole","Organization","CareTeam","Patient")]
      [DataMember]
      public Hl7.Fhir.Model.ResourceReference OnBehalfOf
      {
        get { return _OnBehalfOf; }
        set { _OnBehalfOf = value; OnPropertyChanged("OnBehalfOf"); }
      }

      private Hl7.Fhir.Model.ResourceReference _OnBehalfOf;

      public override IDeepCopyable CopyTo(IDeepCopyable other)
      {
        var dest = other as AgentComponent;

        if (dest == null)
        {
          throw new ArgumentException("Can only copy to an object of the same type", "other");
        }

        base.CopyTo(dest);
        if(Type != null) dest.Type = (Hl7.Fhir.Model.CodeableConcept)Type.DeepCopy();
        if(Role != null) dest.Role = new List<Hl7.Fhir.Model.CodeableConcept>(Role.DeepCopy());
        if(Who != null) dest.Who = (Hl7.Fhir.Model.ResourceReference)Who.DeepCopy();
        if(OnBehalfOf != null) dest.OnBehalfOf = (Hl7.Fhir.Model.ResourceReference)OnBehalfOf.DeepCopy();
        return dest;
      }

      public override IDeepCopyable DeepCopy()
      {
        return CopyTo(new AgentComponent());
      }

      ///<inheritdoc />
      public override bool Matches(IDeepComparable other)
      {
        var otherT = other as AgentComponent;
        if(otherT == null) return false;

        if(!base.Matches(otherT)) return false;
        if( !DeepComparable.Matches(Type, otherT.Type)) return false;
        if( !DeepComparable.Matches(Role, otherT.Role)) return false;
        if( !DeepComparable.Matches(Who, otherT.Who)) return false;
        if( !DeepComparable.Matches(OnBehalfOf, otherT.OnBehalfOf)) return false;

        return true;
      }

      public override bool IsExactly(IDeepComparable other)
      {
        var otherT = other as AgentComponent;
        if(otherT == null) return false;

        if(!base.IsExactly(otherT)) return false;
        if( !DeepComparable.IsExactly(Type, otherT.Type)) return false;
        if( !DeepComparable.IsExactly(Role, otherT.Role)) return false;
        if( !DeepComparable.IsExactly(Who, otherT.Who)) return false;
        if( !DeepComparable.IsExactly(OnBehalfOf, otherT.OnBehalfOf)) return false;

        return true;
      }

      [IgnoreDataMember]
      public override IEnumerable<Base> Children
      {
        get
        {
          foreach (var item in base.Children) yield return item;
          if (Type != null) yield return Type;
          foreach (var elem in Role) { if (elem != null) yield return elem; }
          if (Who != null) yield return Who;
          if (OnBehalfOf != null) yield return OnBehalfOf;
        }
      }

      [IgnoreDataMember]
      public override IEnumerable<ElementValue> NamedChildren
      {
        get
        {
          foreach (var item in base.NamedChildren) yield return item;
          if (Type != null) yield return new ElementValue("type", Type);
          foreach (var elem in Role) { if (elem != null) yield return new ElementValue("role", elem); }
          if (Who != null) yield return new ElementValue("who", Who);
          if (OnBehalfOf != null) yield return new ElementValue("onBehalfOf", OnBehalfOf);
        }
      }

      protected override bool TryGetValue(string key, out object value)
      {
        switch (key)
        {
          case "type":
            value = Type;
            return Type is not null;
          case "role":
            value = Role;
            return Role?.Any() == true;
          case "who":
            value = Who;
            return Who is not null;
          case "onBehalfOf":
            value = OnBehalfOf;
            return OnBehalfOf is not null;
          default:
            return base.TryGetValue(key, out value);
        }

      }

      protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
      {
        foreach (var kvp in base.GetElementPairs()) yield return kvp;
        if (Type is not null) yield return new KeyValuePair<string,object>("type",Type);
        if (Role?.Any() == true) yield return new KeyValuePair<string,object>("role",Role);
        if (Who is not null) yield return new KeyValuePair<string,object>("who",Who);
        if (OnBehalfOf is not null) yield return new KeyValuePair<string,object>("onBehalfOf",OnBehalfOf);
      }

    }

    /// <summary>
    /// An entity used in this activity
    /// </summary>
    [Serializable]
    [DataContract]
    [FhirType("Provenance#Entity", IsNestedType=true)]
    [BackboneType("Provenance.entity")]
    public partial class EntityComponent : Hl7.Fhir.Model.BackboneElement
    {
      /// <summary>
      /// FHIR Type Name
      /// </summary>
      public override string TypeName { get { return "Provenance#Entity"; } }

      /// <summary>
      /// revision | quotation | source | instantiates | removal
      /// </summary>
      [FhirElement("role", InSummary=true, Order=40)]
      [DeclaredType(Type = typeof(Code))]
      [Binding("ProvenanceEntityRole")]
      [Cardinality(Min=1,Max=1)]
      [DataMember]
      public Code<Hl7.Fhir.Model.Provenance.ProvenanceEntityRole> RoleElement
      {
        get { return _RoleElement; }
        set { _RoleElement = value; OnPropertyChanged("RoleElement"); }
      }

      private Code<Hl7.Fhir.Model.Provenance.ProvenanceEntityRole> _RoleElement;

      /// <summary>
      /// revision | quotation | source | instantiates | removal
      /// </summary>
      /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
      [IgnoreDataMember]
      public Hl7.Fhir.Model.Provenance.ProvenanceEntityRole? Role
      {
        get { return RoleElement != null ? RoleElement.Value : null; }
        set
        {
          if (value == null)
            RoleElement = null;
          else
            RoleElement = new Code<Hl7.Fhir.Model.Provenance.ProvenanceEntityRole>(value);
          OnPropertyChanged("Role");
        }
      }

      /// <summary>
      /// Identity of entity
      /// </summary>
      [FhirElement("what", InSummary=true, Order=50)]
      [CLSCompliant(false)]
      [References("Resource")]
      [Cardinality(Min=1,Max=1)]
      [DataMember]
      public Hl7.Fhir.Model.ResourceReference What
      {
        get { return _What; }
        set { _What = value; OnPropertyChanged("What"); }
      }

      private Hl7.Fhir.Model.ResourceReference _What;

      /// <summary>
      /// Entity is attributed to this agent
      /// </summary>
      [FhirElement("agent", Order=60)]
      [Cardinality(Min=0,Max=-1)]
      [DataMember]
      public List<Hl7.Fhir.Model.Provenance.AgentComponent> Agent
      {
        get { if(_Agent==null) _Agent = new List<Hl7.Fhir.Model.Provenance.AgentComponent>(); return _Agent; }
        set { _Agent = value; OnPropertyChanged("Agent"); }
      }

      private List<Hl7.Fhir.Model.Provenance.AgentComponent> _Agent;

      public override IDeepCopyable CopyTo(IDeepCopyable other)
      {
        var dest = other as EntityComponent;

        if (dest == null)
        {
          throw new ArgumentException("Can only copy to an object of the same type", "other");
        }

        base.CopyTo(dest);
        if(RoleElement != null) dest.RoleElement = (Code<Hl7.Fhir.Model.Provenance.ProvenanceEntityRole>)RoleElement.DeepCopy();
        if(What != null) dest.What = (Hl7.Fhir.Model.ResourceReference)What.DeepCopy();
        if(Agent != null) dest.Agent = new List<Hl7.Fhir.Model.Provenance.AgentComponent>(Agent.DeepCopy());
        return dest;
      }

      public override IDeepCopyable DeepCopy()
      {
        return CopyTo(new EntityComponent());
      }

      ///<inheritdoc />
      public override bool Matches(IDeepComparable other)
      {
        var otherT = other as EntityComponent;
        if(otherT == null) return false;

        if(!base.Matches(otherT)) return false;
        if( !DeepComparable.Matches(RoleElement, otherT.RoleElement)) return false;
        if( !DeepComparable.Matches(What, otherT.What)) return false;
        if( !DeepComparable.Matches(Agent, otherT.Agent)) return false;

        return true;
      }

      public override bool IsExactly(IDeepComparable other)
      {
        var otherT = other as EntityComponent;
        if(otherT == null) return false;

        if(!base.IsExactly(otherT)) return false;
        if( !DeepComparable.IsExactly(RoleElement, otherT.RoleElement)) return false;
        if( !DeepComparable.IsExactly(What, otherT.What)) return false;
        if( !DeepComparable.IsExactly(Agent, otherT.Agent)) return false;

        return true;
      }

      [IgnoreDataMember]
      public override IEnumerable<Base> Children
      {
        get
        {
          foreach (var item in base.Children) yield return item;
          if (RoleElement != null) yield return RoleElement;
          if (What != null) yield return What;
          foreach (var elem in Agent) { if (elem != null) yield return elem; }
        }
      }

      [IgnoreDataMember]
      public override IEnumerable<ElementValue> NamedChildren
      {
        get
        {
          foreach (var item in base.NamedChildren) yield return item;
          if (RoleElement != null) yield return new ElementValue("role", RoleElement);
          if (What != null) yield return new ElementValue("what", What);
          foreach (var elem in Agent) { if (elem != null) yield return new ElementValue("agent", elem); }
        }
      }

      protected override bool TryGetValue(string key, out object value)
      {
        switch (key)
        {
          case "role":
            value = RoleElement;
            return RoleElement is not null;
          case "what":
            value = What;
            return What is not null;
          case "agent":
            value = Agent;
            return Agent?.Any() == true;
          default:
            return base.TryGetValue(key, out value);
        }

      }

      protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
      {
        foreach (var kvp in base.GetElementPairs()) yield return kvp;
        if (RoleElement is not null) yield return new KeyValuePair<string,object>("role",RoleElement);
        if (What is not null) yield return new KeyValuePair<string,object>("what",What);
        if (Agent?.Any() == true) yield return new KeyValuePair<string,object>("agent",Agent);
      }

    }

    /// <summary>
    /// Target Reference(s) (usually version specific)
    /// </summary>
    [FhirElement("target", InSummary=true, Order=90, FiveWs="FiveWs.what[x]")]
    [CLSCompliant(false)]
    [References("Resource")]
    [Cardinality(Min=1,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.ResourceReference> Target
    {
      get { if(_Target==null) _Target = new List<Hl7.Fhir.Model.ResourceReference>(); return _Target; }
      set { _Target = value; OnPropertyChanged("Target"); }
    }

    private List<Hl7.Fhir.Model.ResourceReference> _Target;

    /// <summary>
    /// When the activity occurred
    /// </summary>
    [FhirElement("occurred", Order=100, Choice=ChoiceType.DatatypeChoice, FiveWs="FiveWs.done[x]")]
    [CLSCompliant(false)]
    [AllowedTypes(typeof(Hl7.Fhir.Model.Period),typeof(Hl7.Fhir.Model.FhirDateTime))]
    [DataMember]
    public Hl7.Fhir.Model.DataType Occurred
    {
      get { return _Occurred; }
      set { _Occurred = value; OnPropertyChanged("Occurred"); }
    }

    private Hl7.Fhir.Model.DataType _Occurred;

    /// <summary>
    /// When the activity was recorded / updated
    /// </summary>
    [FhirElement("recorded", InSummary=true, Order=110, FiveWs="FiveWs.recorded")]
    [DataMember]
    public Hl7.Fhir.Model.Instant RecordedElement
    {
      get { return _RecordedElement; }
      set { _RecordedElement = value; OnPropertyChanged("RecordedElement"); }
    }

    private Hl7.Fhir.Model.Instant _RecordedElement;

    /// <summary>
    /// When the activity was recorded / updated
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public DateTimeOffset? Recorded
    {
      get { return RecordedElement != null ? RecordedElement.Value : null; }
      set
      {
        if (value == null)
          RecordedElement = null;
        else
          RecordedElement = new Hl7.Fhir.Model.Instant(value);
        OnPropertyChanged("Recorded");
      }
    }

    /// <summary>
    /// Policy or plan the activity was defined by
    /// </summary>
    [FhirElement("policy", Order=120)]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.FhirUri> PolicyElement
    {
      get { if(_PolicyElement==null) _PolicyElement = new List<Hl7.Fhir.Model.FhirUri>(); return _PolicyElement; }
      set { _PolicyElement = value; OnPropertyChanged("PolicyElement"); }
    }

    private List<Hl7.Fhir.Model.FhirUri> _PolicyElement;

    /// <summary>
    /// Policy or plan the activity was defined by
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public IEnumerable<string> Policy
    {
      get { return PolicyElement != null ? PolicyElement.Select(elem => elem.Value) : null; }
      set
      {
        if (value == null)
          PolicyElement = null;
        else
          PolicyElement = new List<Hl7.Fhir.Model.FhirUri>(value.Select(elem=>new Hl7.Fhir.Model.FhirUri(elem)));
        OnPropertyChanged("Policy");
      }
    }

    /// <summary>
    /// Where the activity occurred, if relevant
    /// </summary>
    [FhirElement("location", Order=130, FiveWs="FiveWs.where[x]")]
    [CLSCompliant(false)]
    [References("Location")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Location
    {
      get { return _Location; }
      set { _Location = value; OnPropertyChanged("Location"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Location;

    /// <summary>
    /// Authorization (purposeOfUse) related to the event
    /// </summary>
    [FhirElement("authorization", Order=140, FiveWs="FiveWs.why[x]")]
    [Binding("ProvenanceReason")]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.CodeableReference> Authorization
    {
      get { if(_Authorization==null) _Authorization = new List<Hl7.Fhir.Model.CodeableReference>(); return _Authorization; }
      set { _Authorization = value; OnPropertyChanged("Authorization"); }
    }

    private List<Hl7.Fhir.Model.CodeableReference> _Authorization;

    /// <summary>
    /// Activity that occurred
    /// </summary>
    [FhirElement("activity", Order=150, FiveWs="FiveWs.why[x]")]
    [Binding("ProvenanceActivity")]
    [DataMember]
    public Hl7.Fhir.Model.CodeableConcept Activity
    {
      get { return _Activity; }
      set { _Activity = value; OnPropertyChanged("Activity"); }
    }

    private Hl7.Fhir.Model.CodeableConcept _Activity;

    /// <summary>
    /// Workflow authorization within which this event occurred
    /// </summary>
    [FhirElement("basedOn", Order=160, FiveWs="FiveWs.why[x]")]
    [CLSCompliant(false)]
    [References("CarePlan","DeviceRequest","ImmunizationRecommendation","MedicationRequest","NutritionOrder","ServiceRequest","Task")]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.ResourceReference> BasedOn
    {
      get { if(_BasedOn==null) _BasedOn = new List<Hl7.Fhir.Model.ResourceReference>(); return _BasedOn; }
      set { _BasedOn = value; OnPropertyChanged("BasedOn"); }
    }

    private List<Hl7.Fhir.Model.ResourceReference> _BasedOn;

    /// <summary>
    /// The patient is the subject of the data created/updated (.target) by the activity
    /// </summary>
    [FhirElement("patient", Order=170, FiveWs="FiveWs.subject[x]")]
    [CLSCompliant(false)]
    [References("Patient")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Patient
    {
      get { return _Patient; }
      set { _Patient = value; OnPropertyChanged("Patient"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Patient;

    /// <summary>
    /// Encounter within which this event occurred or which the event is tightly associated
    /// </summary>
    [FhirElement("encounter", Order=180, FiveWs="FiveWs.why[x]")]
    [CLSCompliant(false)]
    [References("Encounter")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Encounter
    {
      get { return _Encounter; }
      set { _Encounter = value; OnPropertyChanged("Encounter"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Encounter;

    /// <summary>
    /// Actor involved
    /// </summary>
    [FhirElement("agent", InSummary=true, Order=190, FiveWs="FiveWs.who")]
    [Cardinality(Min=1,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.Provenance.AgentComponent> Agent
    {
      get { if(_Agent==null) _Agent = new List<Hl7.Fhir.Model.Provenance.AgentComponent>(); return _Agent; }
      set { _Agent = value; OnPropertyChanged("Agent"); }
    }

    private List<Hl7.Fhir.Model.Provenance.AgentComponent> _Agent;

    /// <summary>
    /// An entity used in this activity
    /// </summary>
    [FhirElement("entity", InSummary=true, Order=200)]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.Provenance.EntityComponent> Entity
    {
      get { if(_Entity==null) _Entity = new List<Hl7.Fhir.Model.Provenance.EntityComponent>(); return _Entity; }
      set { _Entity = value; OnPropertyChanged("Entity"); }
    }

    private List<Hl7.Fhir.Model.Provenance.EntityComponent> _Entity;

    /// <summary>
    /// Signature on target
    /// </summary>
    [FhirElement("signature", Order=210)]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.Signature> Signature
    {
      get { if(_Signature==null) _Signature = new List<Hl7.Fhir.Model.Signature>(); return _Signature; }
      set { _Signature = value; OnPropertyChanged("Signature"); }
    }

    private List<Hl7.Fhir.Model.Signature> _Signature;

    public override IDeepCopyable CopyTo(IDeepCopyable other)
    {
      var dest = other as Provenance;

      if (dest == null)
      {
        throw new ArgumentException("Can only copy to an object of the same type", "other");
      }

      base.CopyTo(dest);
      if(Target != null) dest.Target = new List<Hl7.Fhir.Model.ResourceReference>(Target.DeepCopy());
      if(Occurred != null) dest.Occurred = (Hl7.Fhir.Model.DataType)Occurred.DeepCopy();
      if(RecordedElement != null) dest.RecordedElement = (Hl7.Fhir.Model.Instant)RecordedElement.DeepCopy();
      if(PolicyElement != null) dest.PolicyElement = new List<Hl7.Fhir.Model.FhirUri>(PolicyElement.DeepCopy());
      if(Location != null) dest.Location = (Hl7.Fhir.Model.ResourceReference)Location.DeepCopy();
      if(Authorization != null) dest.Authorization = new List<Hl7.Fhir.Model.CodeableReference>(Authorization.DeepCopy());
      if(Activity != null) dest.Activity = (Hl7.Fhir.Model.CodeableConcept)Activity.DeepCopy();
      if(BasedOn != null) dest.BasedOn = new List<Hl7.Fhir.Model.ResourceReference>(BasedOn.DeepCopy());
      if(Patient != null) dest.Patient = (Hl7.Fhir.Model.ResourceReference)Patient.DeepCopy();
      if(Encounter != null) dest.Encounter = (Hl7.Fhir.Model.ResourceReference)Encounter.DeepCopy();
      if(Agent != null) dest.Agent = new List<Hl7.Fhir.Model.Provenance.AgentComponent>(Agent.DeepCopy());
      if(Entity != null) dest.Entity = new List<Hl7.Fhir.Model.Provenance.EntityComponent>(Entity.DeepCopy());
      if(Signature != null) dest.Signature = new List<Hl7.Fhir.Model.Signature>(Signature.DeepCopy());
      return dest;
    }

    public override IDeepCopyable DeepCopy()
    {
      return CopyTo(new Provenance());
    }

    ///<inheritdoc />
    public override bool Matches(IDeepComparable other)
    {
      var otherT = other as Provenance;
      if(otherT == null) return false;

      if(!base.Matches(otherT)) return false;
      if( !DeepComparable.Matches(Target, otherT.Target)) return false;
      if( !DeepComparable.Matches(Occurred, otherT.Occurred)) return false;
      if( !DeepComparable.Matches(RecordedElement, otherT.RecordedElement)) return false;
      if( !DeepComparable.Matches(PolicyElement, otherT.PolicyElement)) return false;
      if( !DeepComparable.Matches(Location, otherT.Location)) return false;
      if( !DeepComparable.Matches(Authorization, otherT.Authorization)) return false;
      if( !DeepComparable.Matches(Activity, otherT.Activity)) return false;
      if( !DeepComparable.Matches(BasedOn, otherT.BasedOn)) return false;
      if( !DeepComparable.Matches(Patient, otherT.Patient)) return false;
      if( !DeepComparable.Matches(Encounter, otherT.Encounter)) return false;
      if( !DeepComparable.Matches(Agent, otherT.Agent)) return false;
      if( !DeepComparable.Matches(Entity, otherT.Entity)) return false;
      if( !DeepComparable.Matches(Signature, otherT.Signature)) return false;

      return true;
    }

    public override bool IsExactly(IDeepComparable other)
    {
      var otherT = other as Provenance;
      if(otherT == null) return false;

      if(!base.IsExactly(otherT)) return false;
      if( !DeepComparable.IsExactly(Target, otherT.Target)) return false;
      if( !DeepComparable.IsExactly(Occurred, otherT.Occurred)) return false;
      if( !DeepComparable.IsExactly(RecordedElement, otherT.RecordedElement)) return false;
      if( !DeepComparable.IsExactly(PolicyElement, otherT.PolicyElement)) return false;
      if( !DeepComparable.IsExactly(Location, otherT.Location)) return false;
      if( !DeepComparable.IsExactly(Authorization, otherT.Authorization)) return false;
      if( !DeepComparable.IsExactly(Activity, otherT.Activity)) return false;
      if( !DeepComparable.IsExactly(BasedOn, otherT.BasedOn)) return false;
      if( !DeepComparable.IsExactly(Patient, otherT.Patient)) return false;
      if( !DeepComparable.IsExactly(Encounter, otherT.Encounter)) return false;
      if( !DeepComparable.IsExactly(Agent, otherT.Agent)) return false;
      if( !DeepComparable.IsExactly(Entity, otherT.Entity)) return false;
      if( !DeepComparable.IsExactly(Signature, otherT.Signature)) return false;

      return true;
    }

    [IgnoreDataMember]
    public override IEnumerable<Base> Children
    {
      get
      {
        foreach (var item in base.Children) yield return item;
        foreach (var elem in Target) { if (elem != null) yield return elem; }
        if (Occurred != null) yield return Occurred;
        if (RecordedElement != null) yield return RecordedElement;
        foreach (var elem in PolicyElement) { if (elem != null) yield return elem; }
        if (Location != null) yield return Location;
        foreach (var elem in Authorization) { if (elem != null) yield return elem; }
        if (Activity != null) yield return Activity;
        foreach (var elem in BasedOn) { if (elem != null) yield return elem; }
        if (Patient != null) yield return Patient;
        if (Encounter != null) yield return Encounter;
        foreach (var elem in Agent) { if (elem != null) yield return elem; }
        foreach (var elem in Entity) { if (elem != null) yield return elem; }
        foreach (var elem in Signature) { if (elem != null) yield return elem; }
      }
    }

    [IgnoreDataMember]
    public override IEnumerable<ElementValue> NamedChildren
    {
      get
      {
        foreach (var item in base.NamedChildren) yield return item;
        foreach (var elem in Target) { if (elem != null) yield return new ElementValue("target", elem); }
        if (Occurred != null) yield return new ElementValue("occurred", Occurred);
        if (RecordedElement != null) yield return new ElementValue("recorded", RecordedElement);
        foreach (var elem in PolicyElement) { if (elem != null) yield return new ElementValue("policy", elem); }
        if (Location != null) yield return new ElementValue("location", Location);
        foreach (var elem in Authorization) { if (elem != null) yield return new ElementValue("authorization", elem); }
        if (Activity != null) yield return new ElementValue("activity", Activity);
        foreach (var elem in BasedOn) { if (elem != null) yield return new ElementValue("basedOn", elem); }
        if (Patient != null) yield return new ElementValue("patient", Patient);
        if (Encounter != null) yield return new ElementValue("encounter", Encounter);
        foreach (var elem in Agent) { if (elem != null) yield return new ElementValue("agent", elem); }
        foreach (var elem in Entity) { if (elem != null) yield return new ElementValue("entity", elem); }
        foreach (var elem in Signature) { if (elem != null) yield return new ElementValue("signature", elem); }
      }
    }

    protected override bool TryGetValue(string key, out object value)
    {
      switch (key)
      {
        case "target":
          value = Target;
          return Target?.Any() == true;
        case "occurred":
          value = Occurred;
          return Occurred is not null;
        case "recorded":
          value = RecordedElement;
          return RecordedElement is not null;
        case "policy":
          value = PolicyElement;
          return PolicyElement?.Any() == true;
        case "location":
          value = Location;
          return Location is not null;
        case "authorization":
          value = Authorization;
          return Authorization?.Any() == true;
        case "activity":
          value = Activity;
          return Activity is not null;
        case "basedOn":
          value = BasedOn;
          return BasedOn?.Any() == true;
        case "patient":
          value = Patient;
          return Patient is not null;
        case "encounter":
          value = Encounter;
          return Encounter is not null;
        case "agent":
          value = Agent;
          return Agent?.Any() == true;
        case "entity":
          value = Entity;
          return Entity?.Any() == true;
        case "signature":
          value = Signature;
          return Signature?.Any() == true;
        default:
          return base.TryGetValue(key, out value);
      }

    }

    protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
    {
      foreach (var kvp in base.GetElementPairs()) yield return kvp;
      if (Target?.Any() == true) yield return new KeyValuePair<string,object>("target",Target);
      if (Occurred is not null) yield return new KeyValuePair<string,object>("occurred",Occurred);
      if (RecordedElement is not null) yield return new KeyValuePair<string,object>("recorded",RecordedElement);
      if (PolicyElement?.Any() == true) yield return new KeyValuePair<string,object>("policy",PolicyElement);
      if (Location is not null) yield return new KeyValuePair<string,object>("location",Location);
      if (Authorization?.Any() == true) yield return new KeyValuePair<string,object>("authorization",Authorization);
      if (Activity is not null) yield return new KeyValuePair<string,object>("activity",Activity);
      if (BasedOn?.Any() == true) yield return new KeyValuePair<string,object>("basedOn",BasedOn);
      if (Patient is not null) yield return new KeyValuePair<string,object>("patient",Patient);
      if (Encounter is not null) yield return new KeyValuePair<string,object>("encounter",Encounter);
      if (Agent?.Any() == true) yield return new KeyValuePair<string,object>("agent",Agent);
      if (Entity?.Any() == true) yield return new KeyValuePair<string,object>("entity",Entity);
      if (Signature?.Any() == true) yield return new KeyValuePair<string,object>("signature",Signature);
    }

  }

}

// end of file
