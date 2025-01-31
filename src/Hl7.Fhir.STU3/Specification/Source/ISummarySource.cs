﻿/* 
 * Copyright (c) 2018, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://github.com/FirelyTeam/firely-net-sdk/blob/master/LICENSE
 */

using Hl7.Fhir.Model;
using System.Collections.Generic;

namespace Hl7.Fhir.Specification.Source
{
    /// <summary>
    /// Interface for browsing and resolving FHIR artifacts by summary.
    /// Efficiently generate summaries and load resources on demand.
    /// </summary>
    public interface ISummarySource
    {
        /// <summary>
        /// Returns a list of artifact summaries with key information
        /// from each FHIR artifact provided by the source.
        /// </summary>
        /// <returns>A sequence of <see cref="ArtifactSummary"/> instances.</returns>
        /// <remarks>
        /// Catches and returns runtime exceptions as error <see cref="ArtifactSummary"/> instances
        /// with <see cref="ArtifactSummary.IsFaulted"/> equal to <c>true</c>
        /// and the <see cref="ArtifactSummary.Error"/> property returning the exception.
        /// </remarks>
        IEnumerable<ArtifactSummary> ListSummaries();

        /// <summary>Load the resource from which the specified summary was generated.</summary>
        /// <param name="summary">An <see cref="ArtifactSummary"/> instance generated by this source.</param>
        /// <returns>A new <see cref="Resource"/> instance, or <c>null</c>.</returns>
        /// <remarks>
        /// The <see cref="ArtifactSummary.Origin"/> and <see cref="ArtifactSummary.Position"/>
        /// summary properties allow the source to identify and resolve the artifact.
        /// </remarks>
        Resource LoadBySummary(ArtifactSummary summary);
    }
}
