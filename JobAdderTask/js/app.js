/*
 * Angular Module Config
 */

( function () {
    'use strict';

    //Directives module
    angular.module( 'directives', [] );


    //Main module
    angular.module( 'JobAdder', ['ui.bootstrap', 'directives'] );


} )();