/*
 * From Now
 */

( function () {
    'use strict';

    angular
        .module( 'filters' )
        .filter( 'fromNow', function () {
               return function ( date ) {

                   return moment.utc( date ).local().fromNow();

               }
           } );

} )();
