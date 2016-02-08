/*
 * Raw Html - no sanitze
 */

( function () {
    'use strict';

    angular
        .module( 'filters' )
        .filter( 'rawHtml', ['$sce', function ( $sce ) {
            return function ( val ) {
                return $sce.trustAsHtml( val );
            };
        }] );
} )();
