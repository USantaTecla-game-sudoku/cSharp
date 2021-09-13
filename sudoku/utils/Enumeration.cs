using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace usantatecla.utils
{
    public abstract class Enumeration : IComparable {
        private readonly int _id;
        private readonly string _value;

        public Enumeration(int id, string value){
            this._id = id;
            this._value = value;
        }

        public override string ToString(){
            return this._value;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

        public static T GetById<T>(int id) where T : Enumeration {
            IEnumerable<T> options = GetAll<T>();
            foreach(T option in options){
                if(option.EqualsId(id)){
                    return option;
                }
            }
            return null;
        }
        public static T GetByValue<T>(string value) where T : Enumeration {
            IEnumerable<T> options = GetAll<T>();
            foreach(T option in options){
                if(option.EqualsValue(value)){
                    return option;
                }
            }
            return null;
        }

        public override bool Equals(object obj){
            Enumeration otherEnum = (Enumeration)obj;
            return this.EqualsId(otherEnum._id) && this.EqualsValue(otherEnum._value);
        }

        private bool EqualsId(int id){
            return this._id.Equals(id);
        }

        private bool EqualsValue(string value){
            return this._value.Equals(value, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return new {_id, _value}.GetHashCode();
        }

        public int CompareTo(object other){
            return _id.CompareTo(((Enumeration)other)._id);
        }
    }
}
