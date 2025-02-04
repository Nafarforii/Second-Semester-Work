﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace SemesterWork2
{
    public class BrandInfo : IEquatable<BrandInfo>
    {
        public BrandInfo(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }
        public string Brand { get; }
        public string Model { get; }

        public bool Equals([AllowNull] BrandInfo other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Brand == other.Brand && this.Model == other.Model;
        }
    }
}
