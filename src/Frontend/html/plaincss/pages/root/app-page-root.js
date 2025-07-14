customElements.define('app-page-root', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    this.outerHTML = document.querySelector('#tpl-app-page-root').innerHTML;
  }
});