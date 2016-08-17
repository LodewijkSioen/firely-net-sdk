﻿/* 
 * Copyright (c) 2015, Furore (info@furore.com) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/ewoutkramer/fhir-net-api/master/LICENSE
 */
using Hl7.ElementModel;
using Hl7.Fhir.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hl7.Fhir.FluentPath.Expressions
{
    internal static class Typecasts
    {
        public delegate object Cast(object source);

        private static object id(object source)
        {
            return source;
        }

        //private static object any2bool(object source)
        //{
        //    if (source == null) return false;

        //    if (source is IEnumerable<IValueProvider>)
        //    {
        //        var list = (IEnumerable<IValueProvider>)source;
        //        if (!list.Any()) return false;

        //        if (list.Count() == 1)
        //            source = list.Single();
        //    }

        //    if (source is IValueProvider)
        //    {
        //        var vp = (IValueProvider)source;
        //        if (vp.Value is bool)
        //            return (bool)vp.Value;
        //    }

        //    // Otherwise, we have "some" content, which we'll consider "true"
        //    return true;
        //}

        private static Cast makeNativeCast(Type to)
        {
            return source =>
                Convert.ChangeType(source, to);
        }

        private static object any2ValueProvider(object source)
        {
            return new ConstantValue(source);
        }

        private static object any2List(object source)
        {
            return FhirValueList.Create(source);
        }

        private static Cast getImplicitCast(Type from, Type to)
        {
            if (to == typeof(object)) return id;
            if (to.IsAssignableFrom(from)) return id;
            //if (to == typeof(bool)) return any2bool;
            if (to == typeof(IValueProvider) && (!typeof(IEnumerable<IValueProvider>).IsAssignableFrom(from))) return any2ValueProvider;
            if (to == typeof(IEnumerable<IValueProvider>)) return any2List;
             
            if (from == typeof(long) && (to == typeof(decimal) || to == typeof(decimal?))) return makeNativeCast(typeof(decimal));
            if (from == typeof(long?) && to == typeof(decimal?)) return makeNativeCast(typeof(decimal?));
            return null;
        }

        internal static object Unbox(object instance, Type to)
        {
            if (instance == null) return null;

            if (typeof(IEnumerable<IValueProvider>).IsAssignableFrom(to)) return instance;

            if (instance is IEnumerable<IValueProvider>)
            {
                var list = (IEnumerable<IValueProvider>)instance;
                if (!list.Any()) return null;
                if (list.Count() == 1)
                    instance = list.Single();
            }

            if (typeof(IValueProvider).IsAssignableFrom(to)) return instance;

            if (instance is IValueProvider)
            {
                var element = (IValueProvider)instance;

                if (element.Value != null)
                    instance = element.Value;
            }

            return instance;
        }

        public static bool CanCastTo(object source, Type to)
        {
            if (source == null)
                return to.IsNullable();

            var from = Unbox(source, to);
            if (from == null)
                return to.IsNullable();

            return getImplicitCast(from.GetType(),to) != null;
        }

        public static bool CanCastTo(Type from, Type to)
        {
            return getImplicitCast(from, to) != null;
        }


        public static T CastTo<T>(object source)
        {
            return (T)CastTo(source, typeof(T));
        }


        public static object CastTo(object source, Type to)
        {
            if (source != null)
            {
                if (to.IsAssignableFrom(source.GetType())) return source;  // for efficiency

                source = Unbox(source, to);

                if (source != null)
                {
                    Cast cast = getImplicitCast(source.GetType(), to);

                    if (cast == null)
                    {
                        //TODO: Spell out why a little bit more explicit than...
                        throw new InvalidCastException("Cannot cast from '{0}' to '{1}'".FormatWith(Typecasts.ReadableFluentPathName(source.GetType()),
                            Typecasts.ReadableFluentPathName(to)));
                    }

                    return cast(source);
                }
            }

            //if source == null, or unboxed source == null....
            if (to == typeof(IEnumerable<IValueProvider>))
                return FhirValueList.Empty;
            if (to.IsNullable())
                return null;
            else
                throw new InvalidCastException("Cannot cast a null value to non-nullable type '{0}'".FormatWith(to.Name));
        }                  

        public static bool IsNullable(this Type t)
        {
           if (!t.IsValueType) return true; // ref-type
           if (Nullable.GetUnderlyingType(t) != null) return true; // Nullable<T>
           return false; // value-type
        }

        public static string ReadableFluentPathName(Type t)
        {
            if (typeof(IEnumerable<IValueProvider>).IsAssignableFrom(t))
                return "collection";
            else if (typeof(IValueProvider).IsAssignableFrom(t))
                return "any single value";
            else
                return t.Name;
        }
    }
}
