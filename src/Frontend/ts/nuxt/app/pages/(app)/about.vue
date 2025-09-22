<script setup lang="ts">
  import { useAppAboutPage } from '~/utils/domain/app/pages/about/app-about-page.composable'

  definePageMeta({
    middleware: ['app-about-page-middleware'],
  })

  useAppAboutPage()
</script>

<template>
  <div>
    <section>
      <h2>About1</h2>
    </section>
    <section>
      <h2>About2</h2>
    </section>
  </div>
</template>
