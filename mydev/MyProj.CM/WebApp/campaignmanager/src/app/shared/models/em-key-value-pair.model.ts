export class KeyValuePair<TKey, TValue>
{
    public key: TKey;
    public value: TValue;
    constructor(key: TKey, value?: TValue) {
        this.key = key;
        this.value = value;
    }
}