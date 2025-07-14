customElements.define('app-footer', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.outerHTML = document.querySelector('#tpl-app-footer').innerHTML;
  }
});