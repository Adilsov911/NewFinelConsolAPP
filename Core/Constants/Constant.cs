﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public enum OwnerOptions
    {
        Exit,
        OwnerCreat,
        UpdateOwner,
        GetAllOwner,
        DeleteOwner
    }
    public enum DrugStoreOptions
    {
        Exit,
        CreatDrugStore,
        UpdateDrugStore,
        GetAllDrugStore,
        DeleteDrugStore,
        GetOwnerDrugStore,
    }
    public enum DruggistOptions
    {
        Exit,
        DruggistCreat,
        DruggistUpdate,
        GetAll,
        Delete,
        GetAllDruggistinDrugStore,
    }


}
