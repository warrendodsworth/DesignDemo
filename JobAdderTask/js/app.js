/*
 * Angular Module Config
 */

( function () {
    'use strict';

    //Directives module
    angular.module( 'filters', [] );


    //Main module
    angular.module( 'JobAdder', ['ui.bootstrap', 'filters'] );

} )();