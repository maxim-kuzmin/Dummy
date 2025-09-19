<script setup lang="ts">
  import { useAppIndexPage } from '~/utils/domain-use-cases/app/pages/index/app-index-page.composable'

  useAppIndexPage()
</script>

<template>
  <div>
    <section>
      <h2>Index1</h2>
    </section>
    <section>
      <h2>Index2</h2>
    </section>
  </div>
</template>
