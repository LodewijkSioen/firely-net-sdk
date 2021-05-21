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
  /// PaymentNotice request
  /// </summary>
  [Serializable]
  [DataContract]
  [FhirType("PaymentNotice", IsResource=true)]
  public partial class PaymentNotice : Hl7.Fhir.Model.DomainResource
  {
    /// <summary>
    /// FHIR Type Name
    /// </summary>
    public override string TypeName { get { return "PaymentNotice"; } }

    /// <summary>
    /// Business Identifier
    /// </summary>
    [FhirElement("identifier", Order=90)]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.Identifier> Identifier
    {
      get { if(_Identifier==null) _Identifier = new List<Hl7.Fhir.Model.Identifier>(); return _Identifier; }
      set { _Identifier = value; OnPropertyChanged("Identifier"); }
    }

    private List<Hl7.Fhir.Model.Identifier> _Identifier;

    /// <summary>
    /// active | cancelled | draft | entered-in-error
    /// </summary>
    [FhirElement("status", InSummary=true, Order=100)]
    [DeclaredType(Type = typeof(Code))]
    [DataMember]
    public Code<Hl7.Fhir.Model.FinancialResourceStatusCodes> StatusElement
    {
      get { return _StatusElement; }
      set { _StatusElement = value; OnPropertyChanged("StatusElement"); }
    }

    private Code<Hl7.Fhir.Model.FinancialResourceStatusCodes> _StatusElement;

    /// <summary>
    /// active | cancelled | draft | entered-in-error
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public Hl7.Fhir.Model.FinancialResourceStatusCodes? Status
    {
      get { return StatusElement != null ? StatusElement.Value : null; }
      set
      {
        if (value == null)
          StatusElement = null;
        else
          StatusElement = new Code<Hl7.Fhir.Model.FinancialResourceStatusCodes>(value);
        OnPropertyChanged("Status");
      }
    }

    /// <summary>
    /// Request reference
    /// </summary>
    [FhirElement("request", Order=110)]
    [CLSCompliant(false)]
    [References("Resource")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Request
    {
      get { return _Request; }
      set { _Request = value; OnPropertyChanged("Request"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Request;

    /// <summary>
    /// Response reference
    /// </summary>
    [FhirElement("response", Order=120)]
    [CLSCompliant(false)]
    [References("Resource")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Response
    {
      get { return _Response; }
      set { _Response = value; OnPropertyChanged("Response"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Response;

    /// <summary>
    /// Payment or clearing date
    /// </summary>
    [FhirElement("statusDate", Order=130)]
    [DataMember]
    public Hl7.Fhir.Model.Date StatusDateElement
    {
      get { return _StatusDateElement; }
      set { _StatusDateElement = value; OnPropertyChanged("StatusDateElement"); }
    }

    private Hl7.Fhir.Model.Date _StatusDateElement;

    /// <summary>
    /// Payment or clearing date
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public string StatusDate
    {
      get { return StatusDateElement != null ? StatusDateElement.Value : null; }
      set
      {
        if (value == null)
          StatusDateElement = null;
        else
          StatusDateElement = new Hl7.Fhir.Model.Date(value);
        OnPropertyChanged("StatusDate");
      }
    }

    /// <summary>
    /// Creation date
    /// </summary>
    [FhirElement("created", Order=140)]
    [DataMember]
    public Hl7.Fhir.Model.FhirDateTime CreatedElement
    {
      get { return _CreatedElement; }
      set { _CreatedElement = value; OnPropertyChanged("CreatedElement"); }
    }

    private Hl7.Fhir.Model.FhirDateTime _CreatedElement;

    /// <summary>
    /// Creation date
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public string Created
    {
      get { return CreatedElement != null ? CreatedElement.Value : null; }
      set
      {
        if (value == null)
          CreatedElement = null;
        else
          CreatedElement = new Hl7.Fhir.Model.FhirDateTime(value);
        OnPropertyChanged("Created");
      }
    }

    /// <summary>
    /// Insurer or Regulatory body
    /// </summary>
    [FhirElement("target", Order=150)]
    [CLSCompliant(false)]
    [References("Organization")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Target
    {
      get { return _Target; }
      set { _Target = value; OnPropertyChanged("Target"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Target;

    /// <summary>
    /// Responsible practitioner
    /// </summary>
    [FhirElement("provider", Order=160)]
    [CLSCompliant(false)]
    [References("Practitioner")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Provider
    {
      get { return _Provider; }
      set { _Provider = value; OnPropertyChanged("Provider"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Provider;

    /// <summary>
    /// Responsible organization
    /// </summary>
    [FhirElement("organization", Order=170)]
    [CLSCompliant(false)]
    [References("Organization")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Organization
    {
      get { return _Organization; }
      set { _Organization = value; OnPropertyChanged("Organization"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Organization;

    /// <summary>
    /// Whether payment has been sent or cleared
    /// </summary>
    [FhirElement("paymentStatus", Order=180)]
    [DataMember]
    public Hl7.Fhir.Model.CodeableConcept PaymentStatus
    {
      get { return _PaymentStatus; }
      set { _PaymentStatus = value; OnPropertyChanged("PaymentStatus"); }
    }

    private Hl7.Fhir.Model.CodeableConcept _PaymentStatus;

    public override IDeepCopyable CopyTo(IDeepCopyable other)
    {
      var dest = other as PaymentNotice;

      if (dest == null)
      {
        throw new ArgumentException("Can only copy to an object of the same type", "other");
      }

      base.CopyTo(dest);
      if(Identifier != null) dest.Identifier = new List<Hl7.Fhir.Model.Identifier>(Identifier.DeepCopy());
      if(StatusElement != null) dest.StatusElement = (Code<Hl7.Fhir.Model.FinancialResourceStatusCodes>)StatusElement.DeepCopy();
      if(Request != null) dest.Request = (Hl7.Fhir.Model.ResourceReference)Request.DeepCopy();
      if(Response != null) dest.Response = (Hl7.Fhir.Model.ResourceReference)Response.DeepCopy();
      if(StatusDateElement != null) dest.StatusDateElement = (Hl7.Fhir.Model.Date)StatusDateElement.DeepCopy();
      if(CreatedElement != null) dest.CreatedElement = (Hl7.Fhir.Model.FhirDateTime)CreatedElement.DeepCopy();
      if(Target != null) dest.Target = (Hl7.Fhir.Model.ResourceReference)Target.DeepCopy();
      if(Provider != null) dest.Provider = (Hl7.Fhir.Model.ResourceReference)Provider.DeepCopy();
      if(Organization != null) dest.Organization = (Hl7.Fhir.Model.ResourceReference)Organization.DeepCopy();
      if(PaymentStatus != null) dest.PaymentStatus = (Hl7.Fhir.Model.CodeableConcept)PaymentStatus.DeepCopy();
      return dest;
    }

    public override IDeepCopyable DeepCopy()
    {
      return CopyTo(new PaymentNotice());
    }

    public override bool Matches(IDeepComparable other)
    {
      var otherT = other as PaymentNotice;
      if(otherT == null) return false;

      if(!base.Matches(otherT)) return false;
      if( !DeepComparable.Matches(Identifier, otherT.Identifier)) return false;
      if( !DeepComparable.Matches(StatusElement, otherT.StatusElement)) return false;
      if( !DeepComparable.Matches(Request, otherT.Request)) return false;
      if( !DeepComparable.Matches(Response, otherT.Response)) return false;
      if( !DeepComparable.Matches(StatusDateElement, otherT.StatusDateElement)) return false;
      if( !DeepComparable.Matches(CreatedElement, otherT.CreatedElement)) return false;
      if( !DeepComparable.Matches(Target, otherT.Target)) return false;
      if( !DeepComparable.Matches(Provider, otherT.Provider)) return false;
      if( !DeepComparable.Matches(Organization, otherT.Organization)) return false;
      if( !DeepComparable.Matches(PaymentStatus, otherT.PaymentStatus)) return false;

      return true;
    }

    public override bool IsExactly(IDeepComparable other)
    {
      var otherT = other as PaymentNotice;
      if(otherT == null) return false;

      if(!base.IsExactly(otherT)) return false;
      if( !DeepComparable.IsExactly(Identifier, otherT.Identifier)) return false;
      if( !DeepComparable.IsExactly(StatusElement, otherT.StatusElement)) return false;
      if( !DeepComparable.IsExactly(Request, otherT.Request)) return false;
      if( !DeepComparable.IsExactly(Response, otherT.Response)) return false;
      if( !DeepComparable.IsExactly(StatusDateElement, otherT.StatusDateElement)) return false;
      if( !DeepComparable.IsExactly(CreatedElement, otherT.CreatedElement)) return false;
      if( !DeepComparable.IsExactly(Target, otherT.Target)) return false;
      if( !DeepComparable.IsExactly(Provider, otherT.Provider)) return false;
      if( !DeepComparable.IsExactly(Organization, otherT.Organization)) return false;
      if( !DeepComparable.IsExactly(PaymentStatus, otherT.PaymentStatus)) return false;

      return true;
    }

    [IgnoreDataMember]
    public override IEnumerable<Base> Children
    {
      get
      {
        foreach (var item in base.Children) yield return item;
        foreach (var elem in Identifier) { if (elem != null) yield return elem; }
        if (StatusElement != null) yield return StatusElement;
        if (Request != null) yield return Request;
        if (Response != null) yield return Response;
        if (StatusDateElement != null) yield return StatusDateElement;
        if (CreatedElement != null) yield return CreatedElement;
        if (Target != null) yield return Target;
        if (Provider != null) yield return Provider;
        if (Organization != null) yield return Organization;
        if (PaymentStatus != null) yield return PaymentStatus;
      }
    }

    [IgnoreDataMember]
    public override IEnumerable<ElementValue> NamedChildren
    {
      get
      {
        foreach (var item in base.NamedChildren) yield return item;
        foreach (var elem in Identifier) { if (elem != null) yield return new ElementValue("identifier", elem); }
        if (StatusElement != null) yield return new ElementValue("status", StatusElement);
        if (Request != null) yield return new ElementValue("request", Request);
        if (Response != null) yield return new ElementValue("response", Response);
        if (StatusDateElement != null) yield return new ElementValue("statusDate", StatusDateElement);
        if (CreatedElement != null) yield return new ElementValue("created", CreatedElement);
        if (Target != null) yield return new ElementValue("target", Target);
        if (Provider != null) yield return new ElementValue("provider", Provider);
        if (Organization != null) yield return new ElementValue("organization", Organization);
        if (PaymentStatus != null) yield return new ElementValue("paymentStatus", PaymentStatus);
      }
    }

  }

}

// end of file
