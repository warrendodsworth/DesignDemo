/*
 * From Now
 */

( function () {
    'use strict';

    angular
        .module( 'directives' )
        .filter( 'fromNow', function () {
               return function ( date ) {

                   return moment.utc( date ).local().fromNow();

               }
           } );

} )();
