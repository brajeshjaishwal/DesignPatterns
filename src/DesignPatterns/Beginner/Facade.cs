﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Beginner
{
    /*
     * A facade is an object that provides a simplified interface to a larger body of code.
     * 
     * We chose to use this pattern in our project because we wanted to have a single interface window to a complex module.
     */
    public class ChromScopeSystem
    {
        // instances of various modules
        private IConfigurationManager _configManager = null;
        private ICollectionManager _collectionManager = null;
        private IDataFileManager _dataFileManager = null;
        private IWorkflowManager _workFlowManager = null;

        /*
         * Work flow manager related methods
         */

        /*
         * Collection manager related methods
         */


    }

    public interface IConfigurationManager { }
    public interface IDataFileManager { }
    public interface IWorkflowManager { }
}
