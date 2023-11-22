#nullable enable

/* 
 * Copyright (c) 2018, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-net-sdk/master/LICENSE
 */

using Hl7.Fhir.Specification;
using System.Collections.Generic;

namespace Hl7.Fhir.ElementModel
{
    /// <summary>
    /// A element within a tree of typed FHIR data.
    /// </summary>
    /// <remarks>
    /// This interface represents FHIR data as a tree of elements, including type information either present in 
    /// the instance or derived from fully aware of the FHIR definitions and types
    /// </remarks>

    public interface ITypedElement : IBaseElementNavigator
    {
        /// <summary>
        /// Enumerate the child nodes present in the source representation (if any)
        /// </summary>
        /// <param name="name">Return only the children with the given name.</param>
        /// <returns></returns>
        new IEnumerable<ITypedElement> Children(string? name = null);

        /// <summary>
        /// An indication of the location of this node within the data represented by the <c>ITypedElement</c>.
        /// </summary>
        /// <remarks>The format of the location is the dotted name of the property, including indices to make
        /// sure repeated occurences of an element can be distinguished. It needs to be sufficiently precise to aid 
        /// the user in locating issues in the data.</remarks>
        string Location { get; }

        IElementDefinitionSummary Definition { get; }
    }
}

#nullable restore