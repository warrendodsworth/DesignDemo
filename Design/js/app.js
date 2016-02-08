/*
 * Angular Module Config
 */

(function () {
  'use strict';

  //Main module
  angular.module('design', ['ui.bootstrap', 'controllers', 'filters']);


  //Directives module
  angular.module('filters', []);

  //Controllers module
  angular.module('controllers', []);

})();