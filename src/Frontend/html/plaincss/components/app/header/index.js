customElements.define('app-header', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.outerHTML = document.querySelector('#tpl-app-header').innerHTML;
  }
});