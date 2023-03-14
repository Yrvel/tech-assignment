import {Pipe, PipeTransform} from '@angular/core';
import { Address } from '../models/address';

@Pipe({name: 'addressFormatted'})
export class AddressFormattedPipe implements PipeTransform {
    transform(address: Address): string {
        if (!address) {
            return '';
        }
        
        return address.suite + ', ' + address.street + ', ' + address.city + ', ' + address.zipcode;
    }
}