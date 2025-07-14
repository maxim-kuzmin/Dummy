customElements.define('app-body', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.outerHTML = document.querySelector('#tpl-app-body').innerHTML;
  }
});