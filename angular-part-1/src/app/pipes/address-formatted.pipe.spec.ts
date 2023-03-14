import { Address } from '../models/address';
import { AddressFormattedPipe } from './address-formatted.pipe';

describe('AddressFormattedPipe', () => {
  it('create an instance of address', () => {
    const pipe = new AddressFormattedPipe();
    expect(pipe).toBeTruthy();
  });

  it('Format an address', () => {
    const pipe = new AddressFormattedPipe();
    const expectedAddressFormatted = 'Apt. 556, Kulas Light, Gwenborough, 92998-3874';

    const actualAddress = new Address('Apt. 556', 'Kulas Light', '92998-3874', 'Gwenborough')
    expect(pipe.transform(actualAddress)).toBe(expectedAddressFormatted);
  });

});
